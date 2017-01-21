using UnityEngine;

public class MainCollider : MonoBehaviour {

    public bool colliding;
    private Collider2D collidingObject;
    private PlayerManager mPlayerManager;

    private Collider2D mCollider2D;

    private bool[] hitted_by_player = { false, false, false, false };
    
    void Start () {
        mCollider2D = GetComponent<Collider2D>();
        mPlayerManager = FindObjectOfType<PlayerManager>();
    }
	
	void Update () {
        //if (collidingObject != null)
        //{
        //    //BoundsContainedPercentage(collidingObject.bounds, mCollider2D.bounds);
        //    Debug.Log("% of collision " + BoundsContainedPercentage(collidingObject.bounds, mCollider2D.bounds));
        //}
    }

    public void GetScore(int player_number)
    {
        PlayerManager.ScoreType ret = PlayerManager.ScoreType.Miss;

        if (colliding && !hitted_by_player[player_number])
        {
            hitted_by_player[player_number] = true;
            Debug.Log(hitted_by_player[player_number]);
            float collidingPercentatge = BoundsContainedPercentage(collidingObject.bounds, mCollider2D.bounds);

            if (collidingPercentatge < 0.2)
                ret = PlayerManager.ScoreType.Bad;
            else if (collidingPercentatge < 0.5)
                ret = PlayerManager.ScoreType.Ok;
            else if (collidingPercentatge < 0.7)
                ret = PlayerManager.ScoreType.Good;
            else if (collidingPercentatge < 0.9)
                ret = PlayerManager.ScoreType.Perfect; 
        }
        mPlayerManager.Score(player_number, ret);
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
        {
            collidingObject = null;
            hitted_by_player = new bool[] { false, false, false, false };
        }

        colliding = false;
    }
}
