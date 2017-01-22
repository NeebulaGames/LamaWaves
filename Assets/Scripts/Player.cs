using UnityEngine;

public class Player : MonoBehaviour
{
    public int inputNumber;
    public int playerNumber;

    public MainCollider mainCollider;
    private WaveAnimation animation;
    private GameplayManager mGameplayManager;

    private Animator mAnimator;
    
    void Start () {
        animation = GetComponent<WaveAnimation>();
        mAnimator = GetComponent<Animator>();
        mGameplayManager = FindObjectOfType<GameplayManager>();
    }

    public void ToggleAnimation(bool status)
    {
        animation.enabled = status;
    }
    
    void Update () {
        mAnimator.SetBool("smashMode", mGameplayManager.smashMode);

        if (Input.GetButtonDown("A_" + (inputNumber + 1)))
        {
            mainCollider.GetScore(playerNumber, OnScreenButtonManager.ColliderType.Button_A);
        }
        else if (Input.GetButtonDown("B_" + (inputNumber + 1)))
        {
            mainCollider.GetScore(playerNumber, OnScreenButtonManager.ColliderType.Button_B);
        }
    }
}
