using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float moveSpeed, travelSpeed, tiltAmount;
	public Text ammoText, scoreText, highScoreText;
	public bool menuMode;
	int ammoCount, score;
	Rigidbody myRB;
	Vector3 temp;
	bool shoot, alive, goLeft, goRight;
	RaycastHit hit;
	ParticleSystem bulletParticle;
	AudioSource myAudioSource;
	[SerializeField]
	AudioClip shootClip;
	[SerializeField]
	AudioClip reloadClip;
	[SerializeField]
	AudioClip wilhelmClip;

	//public Button leftButton, rightButton;

	void Awake() {
		bulletParticle = GetComponentInChildren<ParticleSystem>();
		myAudioSource = GetComponent<AudioSource>();
//		leftButton = GameObject.Find("Left Button").GetComponent<Button>();
//
//		rightButton = GameObject.Find("Right Button").GetComponent<Button>();

	

	}


	// Use this for initialization
	void Start () {
		if (menuMode) {
			MenuMode();
			return;
		}
		alive = true;
		myRB = GetComponent<Rigidbody>();
		myRB.velocity = new Vector3(0f, 0f, travelSpeed);	
		ammoCount = 50;
		score = 0;
		ammoText.text = "ammo: " + ammoCount;
		scoreText.text = "score: " + score;
		temp = Vector3.zero;
		temp += Vector3.forward * travelSpeed;
		highScoreText.enabled = false;
	}

	void MenuMode() {
		alive = true;

		myRB = GetComponent<Rigidbody>();
		myRB.velocity = new Vector3(0f, 0f, travelSpeed);	

	}
	// Update is called once per frame
	void Update () {
		if (menuMode) {
			return;
		}
		
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("Menu");
		}


		if (!alive) {
			return;
		}



		if (Input.GetKeyDown(KeyCode.Space)) {
			
			//shoot = true;
			bulletParticle.Play();
			myAudioSource.PlayOneShot(shootClip);
			if(--ammoCount < 0)
				ammoCount = 0;
			ammoText.text = "ammo: " + ammoCount;
		}


//		if (hit.transform != null) {
//			Debug.DrawLine(transform.position, hit.point, Color.red);
//			
//		}
	}
	public void ShootButtonDown() {
		if (bulletParticle.isEmitting) {return;}
		if (ammoCount == 0) {return;}

		bulletParticle.Play();
		myAudioSource.PlayOneShot(shootClip);
		if(--ammoCount < 0)
			ammoCount = 0;
		ammoText.text = "ammo: " + ammoCount;
	}

	public void LeftButtonDown() { goLeft = true; }
	public void LeftButtonUp() { goLeft = false; }
	public void RightButtonDown() { goRight = true; }
	public void RightButtonUp() { goRight = false; }



	void FixedUpdate() {
		if (!alive) {
			return;
		}

		//temp = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, travelSpeed);
//		if (false) {
//			temp = Vector3.left * moveSpeed + Vector3.up * travelSpeed;
//		} else if (Input.GetButton("rightButton")) {
//			temp = Vector3.right * moveSpeed + Vector3.up * travelSpeed;
//
//		}

		if (temp.x == 0f) {
			transform.rotation = Quaternion.Euler(Vector3.zero);
		} else if (temp.x > 0f) {
			transform.rotation = Quaternion.Euler(new Vector3((tiltAmount / 2) * temp.x, 0f, -tiltAmount * temp.x));
		} else if (temp.x < 0f) {
			transform.rotation = Quaternion.Euler(new Vector3((tiltAmount / 2) * -temp.x, 0f, -tiltAmount * temp.x ));
		}

		if (goLeft && goRight) {
			temp = Vector3.forward * travelSpeed;
		} else if (goLeft) {
			temp = Vector3.left * moveSpeed + Vector3.forward * travelSpeed;
		} else if (goRight) {
			temp = Vector3.right * moveSpeed + Vector3.forward * travelSpeed;
		} else {
			temp = Vector3.forward * travelSpeed;

		}
		myRB.velocity = temp;


		//Vector3 fwd = transform.TransformDirection(Vector3.forward);


//        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 20f)) {
//			print("Found an object - distance: " + hit.distance);
//
//			if (shoot) {
//				shoot = false;
//
//				if (ammoCount <= 0) {
//					ammoCount = 0;
//					return;
//				}
//				//hit.collider.BroadcastMessage("GotHit");
//				//hit.rigidbody.AddForce(new Vector3(Random.Range(-350f, 350f), 150f, 10f));
//				//hit.rigidbody.AddTorque(15f, Random.Range(-20f, 20f), 0f);
//				//hit.collider.enabled = false;
//
//				//hit.rigidbody.velocity = new Vector3(Random.Range(-10f, 10f), 15f, 10f);
//			}
//		} else {
//			shoot = false;
//		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Enemy") {
			myAudioSource.PlayOneShot(wilhelmClip);
			alive = false;
			myRB.constraints = RigidbodyConstraints.None;
			myRB.AddForce(new Vector3(Random.Range(-10f, 10f), 175f, 10f));
			myRB.AddTorque(40f, Random.Range(-20f, 20f), 0f);
			//myCollider.enabled = false;
			Invoke("BackToMenu", 3f);
			highScoreText.enabled = true;
			highScoreText.text = "score: " + score;
			if (score > PlayerPrefs.GetInt("highscore")) {
				PlayerPrefs.SetInt("highscore", score);
			}
		}
	}

	void BackToMenu() {
		SceneManager.LoadScene("Menu");
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ammo") {
			myAudioSource.PlayOneShot(reloadClip);
			Destroy(other.gameObject);
			ammoCount += Random.Range(1, 9);
			ammoText.text = "ammo: " + ammoCount;
		}
	}

	public void IncreaseScore() {
		scoreText.text = "score: " + ++score;
	}
}
