using LamaWaves.Scripts;
using UnityEngine;

public class MainCollider : MonoBehaviour
{
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

    public void GetScore(int player_number, OnScreenButtonManager.ColliderType button_type)
    {
        if (mPlayerManager != null)
        {
            ScoreType ret = ScoreType.Miss;

            if (collidingObject != null && !hitted_by_player[player_number])
            {
                hitted_by_player[player_number] = true;
                //Debug.Log(collidingObject.GetComponent<MovingButton>().buttonType);
                if (button_type == collidingObject.GetComponent<MovingButton>().buttonType)
                {
                    int collidingPercentatge = Mathf.FloorToInt(BoundsContainedPercentage(collidingObject.bounds, mCollider2D.bounds) * 100);
                    //Debug.Log("Percentage: " + collidingPercentatge);
                    if (collidingPercentatge < 20)
                        ret = ScoreType.Bad;
                    else if (collidingPercentatge < 60)
                        ret = ScoreType.Ok;
                    else if (collidingPercentatge < 90)
                        ret = ScoreType.Good;
                    else
                        ret = ScoreType.Perfect;
                }
            }
            mPlayerManager.Score(player_number, ret);
        }
    }

    private float BoundsContainedPercentage(Bounds obj, Bounds region)
    {
        float dist = Mathf.Abs(obj.max[0] - region.max[0]);
        return Mathf.Clamp01(1f - dist / obj.size[0]);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collidingObject != null)
        {
            for (int i = 0; i < mPlayerManager.PlayerCount(); i++)
            {
                if (!hitted_by_player[i])
                    mPlayerManager.Score(i, ScoreType.Miss);
            }
        }

        hitted_by_player = new bool[] { false, false, false, false };
        collidingObject = other;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other == collidingObject)
        {
            for (int i = 0; i < mPlayerManager.PlayerCount(); i++)
            {
                if (!hitted_by_player[i])
                    mPlayerManager.Score(i, ScoreType.Miss);
            }

            collidingObject = null;
            hitted_by_player = new bool[] { false, false, false, false };
        }
    }
}
