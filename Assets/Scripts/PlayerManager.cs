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
		
	}

    public void Score(int player, ScoreType type)
    {

        if (mGameplayManager.smashMode)
            type = ScoreType.Good;

        if (gauge[player] >= 1000)
        {
            gauge[player] = 1000;
            if ((int)type != 1)
                scores[player] = 50 * (int)type * gauge_bonus;
            else
                gauge[player] -= 100;
        }
        else
        {
            scores[player] = 50 * (int)type;
            gauge[player] = 2 * (int)type - 1;
        }
        //TODO: check if player's gaugue is FULL, then multiply the score and dont increment gaugue, just decrease if miss
        
        Debug.Log("Player: " + player + " - Type: " + type);
    }
}
