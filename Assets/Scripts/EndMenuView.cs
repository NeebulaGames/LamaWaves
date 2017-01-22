using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuView : MonoBehaviour {

	private GameObject[] _scoreWalls = new GameObject[4];
	private Text[] _scoreText = new Text[4];
	private Text[] _missesText = new Text[4];
	private Text[] _hitsText = new Text[4];

	void Awake()
	{
		_scoreWalls[0] = transform.Find("Score_Red").gameObject;
		_scoreWalls[1] = transform.Find("Score_Yellow").gameObject;
		_scoreWalls[2] = transform.Find("Score_Green").gameObject;
		_scoreWalls[3] = transform.Find("Score_Blue").gameObject;

		_scoreText[0] = transform.Find("Score_Red/ScoreText").GetComponent<Text>();
		_scoreText[1] = transform.Find("Score_Yellow/ScoreText").GetComponent<Text>();
		_scoreText[2] = transform.Find("Score_Green/ScoreText").GetComponent<Text>();
		_scoreText[3] = transform.Find("Score_Blue/ScoreText").GetComponent<Text>();

		_missesText[0] = transform.Find("Score_Red/MissesText").GetComponent<Text>();
		_missesText[1] = transform.Find("Score_Yellow/MissesText").GetComponent<Text>();
		_missesText[2] = transform.Find("Score_Green/MissesText").GetComponent<Text>();
		_missesText[3] = transform.Find("Score_Blue/MissesText").GetComponent<Text>();

		_hitsText[0] = transform.Find("Score_Red/HitsText").GetComponent<Text>();
		_hitsText[1] = transform.Find("Score_Yellow/HitsText").GetComponent<Text>();
		_hitsText[2] = transform.Find("Score_Green/HitsText").GetComponent<Text>();
		_hitsText[3] = transform.Find("Score_Blue/HitsText").GetComponent<Text>();

		foreach (GameObject scoreWall in _scoreWalls)
		{
			scoreWall.SetActive(false);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetScore(int player, int score)
	{
		_scoreText[player].text = score.ToString("000000");
	}

	public void SetMisses(int player, int misses)
	{
		_missesText[player].text = misses.ToString();
	}

	public void SetHits(int player, int hits)
	{
		_hitsText[player].text = hits.ToString();
	}

	public void ShowScoreWall(int player, bool winner, Vector3 absPos)
	{
		_scoreWalls[player].SetActive(true);
	    if (winner)
	    {
	        switch (player)
	        {
	            case 0:
	                _scoreWalls[player].transform.Find("Winner_Red").gameObject.SetActive(true);
	                break;
	            case 1:
	                _scoreWalls[player].transform.Find("Winner_Yellow").gameObject.SetActive(true);
	                break;
	            case 2:
	                _scoreWalls[player].transform.Find("Winner_Green").gameObject.SetActive(true);
	                break;
	            case 3:
	                _scoreWalls[player].transform.Find("Winner_Blue").gameObject.SetActive(true);
	                break;
	        }
	    }

	    Transform wall = _scoreWalls[player].transform;
	    absPos.z = wall.position.z;
	    absPos.y = wall.position.y;
        wall.position = absPos;
	    //wall.DOLocalMoveZ(0f, 0f);
	}
}
