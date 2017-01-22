using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LamaWaves.Scripts;

public class LamaResultsController : MonoBehaviour {
	
	public Sprite[] ratingMessagesSprites = new Sprite[5];

	public GameObject ratingMessageObject;
	public int numLama;

	private Dictionary<ScoreType, Sprite> _ratingMessagesMap = new Dictionary<ScoreType, Sprite>();


	void Awake()
	{
		_ratingMessagesMap.Add(ScoreType.Bad, ratingMessagesSprites[0]);
		_ratingMessagesMap.Add(ScoreType.Good, ratingMessagesSprites[1]);
		_ratingMessagesMap.Add(ScoreType.Miss, ratingMessagesSprites[2]);
		_ratingMessagesMap.Add(ScoreType.Ok, ratingMessagesSprites[3]);
		_ratingMessagesMap.Add(ScoreType.Perfect, ratingMessagesSprites[4]);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp(KeyCode.Q))
		{
			ShowMessage(ScoreType.Bad);
		}

		if (Input.GetKeyUp(KeyCode.W))
		{
			ShowMessage(ScoreType.Good);
		}

		if (Input.GetKeyUp(KeyCode.E))
		{
			ShowMessage(ScoreType.Miss);
		}

		if (Input.GetKeyUp(KeyCode.R))
		{
			ShowMessage(ScoreType.Ok);
		}

		if (Input.GetKeyUp(KeyCode.T))
		{
			ShowMessage(ScoreType.Perfect);
		}
	}

	public void ShowMessage(ScoreType ratingMessage)
	{
		GameObject go = Instantiate(ratingMessageObject, transform.Find("/GameEntities/UI/Canvas"));
		Vector3 originalRatingMessagePosition = ratingMessageObject.transform.position;
		go.transform.position = new Vector3(transform.position.x, 
		                                         originalRatingMessagePosition.y, 
		                                         originalRatingMessagePosition.z);
		go.GetComponent<RatingMessageController>().PlayMessage(_ratingMessagesMap[ratingMessage]);
	}
}
