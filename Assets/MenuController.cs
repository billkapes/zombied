using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	public Text highscoreText;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey("highscore")) {
			PlayerPrefs.SetInt("highscore", 0);
		}
		highscoreText.text = "hi score: " + PlayerPrefs.GetInt("highscore");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void StartGame() {
		SceneManager.LoadScene("Main");
	}

}
