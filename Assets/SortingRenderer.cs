using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingRenderer : MonoBehaviour {

	//public int sortingOrder;
	//public string sortingLayerName;

	// Use this for initialization
	void Start () {
		//transform.GetComponent<Renderer>().sortingLayerName = sortingLayerName;
		//transform.GetComponent<Renderer>().sortingOrder = sortingOrder;
		transform.GetComponent<Material>().renderQueue = 6000;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(gameObject.name + " " + transform.GetComponent<Renderer>().sortingLayerName + " " + transform.GetComponent<Renderer>().sortingOrder);
	}
}
