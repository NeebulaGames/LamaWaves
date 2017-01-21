using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int playerNumber;

    public MainCollider mMainCollider;

    public bool buttonPushed = false;

	// Use this for initialization
	void Start () {
        mMainCollider = FindObjectOfType<MainCollider>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(mMainCollider.GetScore());
        }

		
	}
}
