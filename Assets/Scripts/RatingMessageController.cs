using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingMessageController : MonoBehaviour {

	private Image _image;
	private Animation _animation;

	void Awake()
	{
		_image = GetComponent<Image>();
		_animation = GetComponent<Animation>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayMessage(Sprite sprite)
	{
		_image.sprite = sprite;
		_animation.Play();
	}

	void DestroyItSelf()
	{
		Destroy(gameObject);
	}
}
