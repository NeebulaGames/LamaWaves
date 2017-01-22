using UnityEngine;

public class Player : MonoBehaviour
{
    public int inputNumber;
    public int playerNumber;

    private MainCollider mMainCollider;
    private WaveAnimation animation;
    
    void Start () {
        mMainCollider = FindObjectOfType<MainCollider>();
        animation = GetComponent<WaveAnimation>();
    }

    public void ToggleAnimation(bool status)
    {
        animation.enabled = status;
    }
    
    void Update () {

        if (Input.GetButtonDown("A_" + (inputNumber + 1)))
        {
            Debug.Log("Player " + inputNumber + " A");
            mMainCollider.GetScore(playerNumber, OnScreenButtonManager.ColliderType.Button_A);
        }
        else if (Input.GetButtonDown("B_" + (inputNumber + 1)))
        {
            mMainCollider.GetScore(playerNumber, OnScreenButtonManager.ColliderType.Button_B);
        }
    }
}
