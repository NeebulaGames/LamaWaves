using UnityEngine;

public class Player : MonoBehaviour {

    public int playerNumber;

    private MainCollider mMainCollider;
    
	void Start () {
        mMainCollider = FindObjectOfType<MainCollider>();
    }
	
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            mMainCollider.GetScore(playerNumber);
        }
	}
}
