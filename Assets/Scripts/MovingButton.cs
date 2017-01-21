using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingButton : MonoBehaviour {

    public enum ColliderType
    {
        Button_A,
        Button_B
    }

    public ColliderType mColliderType;
    
    // Use this for initialization
    void Start () {
        //testing remove later
       transform.DOLocalMoveX(-50, 3).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
