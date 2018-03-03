using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {
	Transform thePlayer;
	float lerptime;
	Vector3 temp;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.FindObjectOfType<PlayerController>().transform;
		lerptime = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (thePlayer.transform.position.z > (transform.position.z + 50f)) {
			temp = transform.position += Vector3.forward * 200f;

			lerptime = 0f;
		}
		if (lerptime < 1f) {
			transform.position = Vector3.Lerp(temp - Vector3.up * 10f, temp, lerptime);	
		} else {
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
		}

		lerptime += Time.deltaTime / 2f;
	}
}
