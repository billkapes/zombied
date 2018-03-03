using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float  cameraSpeed;
	PlayerController thePlayer;
	float offsetZ, offsetX;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
		offsetZ = transform.position.z;
		offsetX = transform.position.x;
//		myHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(thePlayer.transform.position.x + offsetX, transform.position.y, thePlayer.transform.position.z + offsetZ);
//		Vector3 temp = Vector3.Lerp(transform.position, new Vector3(thePlayer.transform.position.x, transform.position.y, transform.position.z + offset), cameraSpeed * Time.deltaTime ) ;
//		temp.z = thePlayer.transform.position.z + offset;
//		transform.position = temp;

//		float step = cameraSpeed * Time.deltaTime;
//		Vector3 temp = Vector3.MoveTowards(transform.position, thePlayer.transform.position, step);
//		temp.y = myHeight;
//		temp.z = thePlayer.transform.position.z + offset;
//		transform.position = temp;

//		float theX = Mathf.MoveTowards(transform.position.x, thePlayer.transform.position.x, step);

//		transform.position = new Vector3 (theX, transform.position.y, thePlayer.transform.position.z + offset);

		//transform.position = Vector3.Lerp(transform.position, new Vector3(thePlayer.transform.position.x + (moveAhead * thePlayer.transform.localScale.x), thePlayer.transform.position.y, transform.position.z), cameraSpeed * Time.deltaTime);
	}
}
