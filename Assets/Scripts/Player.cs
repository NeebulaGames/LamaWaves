using UnityEngine;

public class Player : MonoBehaviour
{
    public int inputNumber;
    public int playerNumber;

    private MainCollider mMainCollider;
    
    void Start () {
        mMainCollider = FindObjectOfType<MainCollider>();
    }
    
    void Update () {

        if (Input.GetButtonDown("A_" + (inputNumber + 1)))
        {
            mMainCollider.GetScore(playerNumber, OnScreenButtonManager.ColliderType.Button_A);
        }
        else if (Input.GetButtonDown("B_" + (inputNumber + 1)))
        {
            mMainCollider.GetScore(playerNumber, OnScreenButtonManager.ColliderType.Button_B);
        }
    }
}
