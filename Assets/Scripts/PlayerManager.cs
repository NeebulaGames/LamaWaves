using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int gauge_bonus = 2;
    public enum ScoreType
    {
        Miss,
        Bad,
        Ok,
        Good,
        Perfect
    }

    private int[] scores = { 0, 0, 0, 0 };
    private int[] gauge = { 0, 0, 0, 0 };
    private GameplayManager mGameplayManager;
    private List<Player> playerList;
    
    void Start () {
        mGameplayManager = FindObjectOfType<GameplayManager>();
    }
    
    void Update () {
        //Debug.Log("Player: " + 1 + " - Score: " + scores[0] + " - Gauge: " + gauge[0]);
    }

    public void Score(int player, ScoreType type)
    {

        if (mGameplayManager.smashMode)
            type = ScoreType.Good;

        if (gauge[player] >= 1000)
        {
            if (type != 0)
                scores[player] += 50 * (int)type * gauge_bonus;
            else
                gauge[player] -= 100;
        }
        else
        {
            scores[player] += 50 * (int)type;
            gauge[player] += 20 * (int)type - 1;
        }

        gauge[player] = Mathf.Clamp(gauge[player], 0, 1000);
        //Debug.Log("Player: " + player + " - Score: " + scores[player] + " - Gauge: " + gauge[player]);
    }
}
