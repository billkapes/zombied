using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
	public float theTime = 10f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, theTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
