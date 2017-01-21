using System.Collections.Generic;
using UnityEngine;

namespace LamaWaves.Scripts
{
	public enum ScoreType
	{
		Miss,
		Bad,
		Ok,
		Good,
		Perfect
	}

public class PlayerManager : MonoBehaviour
{
	public BottomUiView bottomUiView;

<<<<<<< master
    private int[] scores = { 0, 0, 0, 0 };
    private int[] gauge = { 0, 0, 0, 0 };
    private GameplayManager mGameplayManager;
    private List<Player> playerList;
    public int gauge_bonus = 2;

	public LamaResultsController[] lamaResultsControllers = new LamaResultsController[4];

    void Start () {
        mGameplayManager = FindObjectOfType<GameplayManager>();
        //StartCoroutine(mGameplayManager.CountdownStartGame()); //just for test
    }
    
    void Update () {
        //Debug.Log("Player: " + 1 + " - Score: " + scores[0] + " - Gauge: " + gauge[0]);
    }
=======
		public int gauge_bonus = 2;
>>>>>>> Set inGameUi active

	public void Score(int player, ScoreType type)
	{
		
		ShowLamaResult(player, type);

<<<<<<< master
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
=======
	    private int[] scores = { 0, 0, 0, 0 };
	    private int[] gauge = { 0, 0, 0, 0 };
	    private GameplayManager mGameplayManager;
	    private List<Player> playerList;
	    
	    void Start () {
	        mGameplayManager = FindObjectOfType<GameplayManager>();
	        //StartCoroutine(mGameplayManager.CountdownStartGame()); //just for test
	    }
	    
	    void Update () {
	        //Debug.Log("Player: " + 1 + " - Score: " + scores[0] + " - Gauge: " + gauge[0]);
	    }
>>>>>>> Set inGameUi active

		gauge[player] = Mathf.Clamp(gauge[player], 0, 1000);

		bottomUiView.SetScoreText(player, scores[player]);
		bottomUiView.SetGauge(player, gauge[player]);

		//Debug.Log("Player: " + player + " - Score: " + scores[player] + " - Gauge: " + gauge[player]);
	}

	public void ShowLamaResult(int lamaPlayer, ScoreType resultType)
	{
		lamaResultsControllers[lamaPlayer].ShowMessage(resultType);
	}
	}
}