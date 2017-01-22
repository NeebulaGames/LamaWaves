using UnityEngine;

public class Player : MonoBehaviour
{
    public int inputNumber;
    public int playerNumber;

    public MainCollider mainCollider;
    private WaveAnimation animation;
    
    void Start () {
        animation = GetComponent<WaveAnimation>();
    }

    public void ToggleAnimation(bool status)
    {
        animation.enabled = status;
    }
    
    void Update () {

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
