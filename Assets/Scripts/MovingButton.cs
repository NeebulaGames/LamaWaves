using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MovingButton : MonoBehaviour
{
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Init(OnScreenButtonManager.ColliderType colliderType, float speedFactor, float maxX)
    {
        Debug.Log("Size Delta: " + maxX);

        transform.DOLocalMoveX(-maxX, maxX * speedFactor).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));

        switch (colliderType)
        {
            case OnScreenButtonManager.ColliderType.Button_A:
                image.sprite = Resources.Load<Sprite>("a_button");
                break;
            case OnScreenButtonManager.ColliderType.Button_B:
                image.sprite = Resources.Load<Sprite>("b_button");
                break;
        }
    }
}
