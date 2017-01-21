using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingRenderer : MonoBehaviour {

	public int sortingOrder;
	public string sortingLayerName;

	// Use this for initialization
	void Start () {
		transform.GetComponent<MeshRenderer>().sortingLayerName = sortingLayerName;
		transform.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
