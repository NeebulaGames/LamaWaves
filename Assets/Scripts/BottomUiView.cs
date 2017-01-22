﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomUiView : MonoBehaviour {

	Image redScoreFull;
	Image yellowScoreFull;
	Image greenScoreFull;
	Image blueScoreFull;

	Text redScoreText;
	Text yellowScoreText;
	Text greenScoreText;
	Text blueScoreText;

	void Awake()
	{
		redScoreFull = transform.Find("RedScore_Empty/RedScore_Full").GetComponent<Image>();
		yellowScoreFull = transform.Find("YellowScore_Empty/YellowScore_Full").GetComponent<Image>();
		greenScoreFull = transform.Find("GreenScore_Empty/GreenScore_Full").GetComponent<Image>();
		blueScoreFull = transform.Find("BlueScore_Empty/BlueScore_Full").GetComponent<Image>();

		redScoreText = transform.Find("RedScore_Empty/RedScoreText").GetComponent<Text>();
		yellowScoreText = transform.Find("YellowScore_Empty/YellowScoreText").GetComponent<Text>();
		greenScoreText = transform.Find("GreenScore_Empty/GreenScoreText").GetComponent<Text>();
		blueScoreText = transform.Find("BlueScore_Empty/BlueScoreText").GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetScoreText(int player, int score)
	{
		switch (player)
		{
			case 0:
				redScoreText.text = score.ToString("000000");
				break;
			case 1:
				yellowScoreText.text = score.ToString("000000");
				break;
			case 2:
				greenScoreText.text = score.ToString("000000");
				break;
			case 3:
				blueScoreText.text = score.ToString("000000");
				break;
		}
	}

	public void SetGauge(int player, int gaugue)
	{
		switch (player)
		{
			case 0:
				redScoreFull.fillAmount = gaugue/1000;
				break;
			case 1:
				yellowScoreFull.fillAmount = gaugue/1000;
				break;
			case 2:
				greenScoreFull.fillAmount = gaugue/1000;
				break;
			case 3:
				blueScoreFull.fillAmount = gaugue/1000;
				break;
		}
	}
}