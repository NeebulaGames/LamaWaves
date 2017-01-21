using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamaResultsController : MonoBehaviour {

	public enum RatingMessage
	{
		Bad,
		Good,
		Missed,
		Ok,
		Perfect
	}

	public Sprite[] ratingMessagesSprites = new Sprite[5];

	//public Animation missAnim;
	public GameObject ratingMessageObject;

	private Dictionary<RatingMessage, Sprite> _ratingMessagesMap = new Dictionary<RatingMessage, Sprite>();


	void Awake()
	{
		_ratingMessagesMap.Add(RatingMessage.Bad, ratingMessagesSprites[0]);
		_ratingMessagesMap.Add(RatingMessage.Good, ratingMessagesSprites[1]);
		_ratingMessagesMap.Add(RatingMessage.Missed, ratingMessagesSprites[2]);
		_ratingMessagesMap.Add(RatingMessage.Ok, ratingMessagesSprites[3]);
		_ratingMessagesMap.Add(RatingMessage.Perfect, ratingMessagesSprites[4]);
	}

	// Use this for initialization
	void Start () {
		//missAnim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp(KeyCode.Q))
		{
			ShowMessage(RatingMessage.Bad);
		}

		if (Input.GetKeyUp(KeyCode.W))
		{
			ShowMessage(RatingMessage.Good);
		}

		if (Input.GetKeyUp(KeyCode.E))
		{
			ShowMessage(RatingMessage.Missed);
		}

		if (Input.GetKeyUp(KeyCode.R))
		{
			ShowMessage(RatingMessage.Ok);
		}

		if (Input.GetKeyUp(KeyCode.T))
		{
			ShowMessage(RatingMessage.Perfect);
		}
	}

	public void ShowMessage(RatingMessage ratingMessage)
	{
		GameObject go = Instantiate(ratingMessageObject, transform.Find("/Canvas"));
		go.GetComponent<RatingMessageController>().PlayMessage(_ratingMessagesMap[ratingMessage]);
	}
}
