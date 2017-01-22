using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

public class OnScreenButtonManager : MonoBehaviour
{
    public enum ColliderType
    {
        Button_A,
        Button_B
    }

    public GameObject countdown3;
    public GameObject countdown2;
    public GameObject countdown1;
    public GameObject countdownSmash;
    public GameObject countdownRelax;

    public Transform buttonsContainer;
	public MainCollider mainCollider;

    private GameplayManager gameplay;
    private AudioManager audioManager;

    private bool started;
    private const float speedFactor = 6f / 1080f;
    private float speed;
    private float radixTime;
    private bool countdown = false;
    private bool smash = false;
    private Coroutine buttonsCoroutine;
    private RectTransform canvasRect;

    private MovingButton baseButton;

    void Awake()
    {
        started = false;
        gameplay = GetComponent<GameplayManager>();
        audioManager = GetComponent<AudioManager>();
        canvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        speed = canvasRect.sizeDelta.x * speedFactor;
        radixTime = speed / 50f;

        baseButton = Resources.Load<MovingButton>("MovingButton");
    }

    public void Init()
    {
        smash = false;
        countdown = false;
        started = true;
        buttonsContainer.gameObject.SetActive(true);
        buttonsCoroutine = StartCoroutine(GenerateButtons());
		mainCollider.gameObject.SetActive(true);
    }

    void OnDisable()
    {
        if (buttonsCoroutine != null)
            StopCoroutine(buttonsCoroutine);
        buttonsContainer.gameObject.SetActive(false);
		mainCollider.gameObject.SetActive(false);
    }

    private IEnumerator GenerateButtons()
    {
        while (!smash && !countdown)
        {
            int buttonAmmount = Random.Range(0, 2) == 0 ? 1 : 3;
            for (int i = 0; i < buttonAmmount; ++i)
            {
                CreateButton((ColliderType) Random.Range(0, 2), Vector3.one * 100 * (i + 1), canvasRect.sizeDelta.x + 100 * (3 - i));
            }

            float timeToWait = Random.Range(1f, 3f);
            //Debug.Log("Waiting " + timeToWait + "s");
            
            yield return new WaitForSeconds(radixTime * 2f * buttonAmmount + timeToWait + 0.1f);
        }
    }

    private MovingButton CreateButton(ColliderType button, Vector3 localPosition, float end)
    {
        MovingButton btn = Instantiate(baseButton, buttonsContainer);
        btn.transform.localScale = Vector3.one;
        localPosition.y = -100;
        localPosition.z = 0;
        btn.transform.localPosition = localPosition;
        btn.Init(button, speedFactor, end, canvasRect.sizeDelta.x);
        return btn;
    }

   
    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(4.8f);

        GameObject instance;
        GameObject canvas = GameObject.Find("Canvas");
        Vector3 position = new Vector3(0f, 250f, 0f);
        Vector3 scale = new Vector3(1f, 1f, 0f);

        instance = Instantiate(countdown3, canvas.transform);
        instance.transform.localPosition = position;
        instance.transform.localScale = scale;
        instance.GetComponent<Image>().CrossFadeAlpha(0, 1.4f, false);
        instance.transform.DOScale(2, 1.4f).OnComplete(() => Destroy(instance));
        yield return new WaitForSeconds(1.4f);

        instance = Instantiate(countdown2, canvas.transform);
        instance.transform.localPosition = position;
        instance.transform.localScale = scale;
        instance.GetComponent<Image>().CrossFadeAlpha(0, 1.4f, false);
        instance.transform.DOScale(2, 1.4f).OnComplete(() => Destroy(instance));
        yield return new WaitForSeconds(1.4f);

        instance = Instantiate(countdown1, canvas.transform);
        instance.transform.localPosition = position;
        instance.transform.localScale = scale;
        instance.GetComponent<Image>().CrossFadeAlpha(0, 1.4f, false);
        instance.transform.DOScale(2, 1.4f).OnComplete(() => Destroy(instance));
        instance.transform.localPosition = position;
        yield return new WaitForSeconds(1.4f);

        if(smash)
            instance = Instantiate(countdownRelax, canvas.transform);
        else
            instance = Instantiate(countdownSmash, canvas.transform);

        instance.transform.localPosition = position;
        instance.transform.localScale = scale;
        instance.GetComponent<Image>().CrossFadeAlpha(0, 1.4f, false);
        instance.transform.DOScale(2, 1.4f).OnComplete(() => Destroy(instance));
        instance.transform.localPosition = position;
        yield return new WaitForSeconds(1.4f);

        //yield return new WaitForSeconds(10f);
        
        countdown = false;
    }

    public void Update()
    {
        if (started && !countdown && audioManager.TimeUntilNextStage() <= 10f)
        {
            smash = gameplay.smashMode;
            StopCoroutine(buttonsCoroutine);
            countdown = true;
            StartCoroutine(Countdown());
        }

        if (started && smash && !countdown && gameplay.smashMode != smash)
        {
            smash = false;
            buttonsCoroutine = StartCoroutine(GenerateButtons());
        }
    }
}
