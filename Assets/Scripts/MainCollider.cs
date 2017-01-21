using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCollider : MonoBehaviour {


    public bool colliding;
    public Collider2D collidingObject;

    private Collider2D mCollider2D;

    // Use this for initialization
    void Start () {
        mCollider2D = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (collidingObject != null)
        //{
        //    //BoundsContainedPercentage(collidingObject.bounds, mCollider2D.bounds);
        //    Debug.Log("% of collision " + BoundsContainedPercentage(collidingObject.bounds, mCollider2D.bounds));
        //}
    }

    public GameplayManager.ScoreType GetScore()
    {
        GameplayManager.ScoreType ret = GameplayManager.ScoreType.Miss;

        if (colliding)
        {
            float collidingPercentatge = BoundsContainedPercentage(collidingObject.bounds, mCollider2D.bounds);

            if (collidingPercentatge < 0.2)
                return GameplayManager.ScoreType.Bad;
            else if (collidingPercentatge < 0.5)
                return GameplayManager.ScoreType.Ok;
            else if (collidingPercentatge < 0.7)
                return GameplayManager.ScoreType.Good;
            else if (collidingPercentatge < 0.9)
                return GameplayManager.ScoreType.Perfect;
        }

        return ret;
    }

    private float BoundsContainedPercentage(Bounds obj, Bounds region)
    {
        float dist = Mathf.Abs(obj.max[0] - region.max[0]);
        return Mathf.Clamp01(1f - dist / obj.size[0]);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        colliding = true;
        collidingObject = other;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other == collidingObject)
            collidingObject = null;
        colliding = false;
    }
}
