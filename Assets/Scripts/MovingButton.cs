using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MovingButton : MonoBehaviour
{
    private Image image;
    public OnScreenButtonManager.ColliderType buttonType;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Init(OnScreenButtonManager.ColliderType colliderType, float speedFactor, float endPosition, float maxX)
    {
        //Debug.Log("Size Delta: " + maxX);

        transform.DOLocalMoveX(-endPosition, maxX * speedFactor).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
        buttonType = colliderType;
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
