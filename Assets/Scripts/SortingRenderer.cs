using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingRenderer : MonoBehaviour {

	//public int sortingOrder;
	//public string sortingLayerName;
	public Material mat;

	// Use this for initialization
	void Start () {
		//transform.GetComponent<Renderer>().sortingLayerName = sortingLayerName;
		//transform.GetComponent<Renderer>().sortingOrder = sortingOrder;
		mat = transform.GetComponent<ParticleSystemRenderer>().material;
		mat.renderQueue = 3001;
	}
	
	// Update is called once per frame
	void Update () {
		mat.renderQueue = 3001;
		//transform.GetComponent<ParticleSystemRenderer>().material.renderQueue = 3001;
		//Debug.Log(gameObject.name + " " + transform.GetComponent<Renderer>().sortingLayerName + " " + transform.GetComponent<Renderer>().sortingOrder);
	}

}

