using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
	Transform thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindObjectOfType<PlayerController>().transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (thePlayer.transform.position.z > (transform.position.z + 50f)) {
			transform.position += Vector3.forward * 200f;
		}
	}
}
