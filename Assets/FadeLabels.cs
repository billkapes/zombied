using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLabels : MonoBehaviour {
	CanvasGroup myCG;
	float fadeTime = 3f;

	void Awake() {
	 myCG = GetComponent<CanvasGroup>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeTime <= 1f) {
			myCG.alpha = fadeTime;
		}
		if (fadeTime > 0f) {
			fadeTime -= Time.deltaTime / 2f;
		}
	}
}
