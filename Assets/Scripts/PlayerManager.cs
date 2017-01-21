using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

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

    private List<Player> playerList;
    
    void Start () {
		
	}
	
	void Update () {
		
	}

    public void Score(int player, ScoreType type)
    {
        //TODO: check if player's gaugue is FULL, then multiply the score and dont increment gaugue, just decrease if miss
        scores[player] = 50 * (int)type;
        gauge[player] = 2 * (int)type - 1;

        Debug.Log("Player: " + player + " - Type: " + type);
    }
}
