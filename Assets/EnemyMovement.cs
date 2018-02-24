using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	PlayerController thePlayer;
	public float speed;
	public Vector3 dir;
	Rigidbody myRB;
	Animator anim;
	AudioSource myAS;

	void Awake() {
		myRB = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		myAS = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10f);
	}

	public void StartMove() {
		thePlayer = FindObjectOfType<PlayerController>();	
		speed = Random.Range(0.001f, 0.01f);

		dir = (thePlayer.transform.position - transform.position).normalized;
		speed = Random.Range(1f, 20f);
		myRB.velocity = dir * speed;
		myRB.velocity = new Vector3(dir.x * speed, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = Vector3.Lerp(transform.position, new Vector3(thePlayer.transform.position.x, transform.position.y, transform.position.z), speed);
	}

	void FixedUpdate () {
		
		//transform.position = Vector3.Lerp(transform.position, new Vector3(thePlayer.transform.position.x, transform.position.y, transform.position.z), speed);
	}

	void OnParticleCollision(GameObject other) {
		if (other.gameObject.tag == "Bullet") {
			GotHit();
		}
	}

	void GotHit() {
		FindObjectOfType<PlayerController>().IncreaseScore();
		myAS.PlayScheduled(0.3);
		myRB.AddForce(new Vector3(Random.Range(-350f, 350f), 150f, 10f));
		myRB.AddTorque(15f, Random.Range(-20f, 20f), 0f);
		this.gameObject.GetComponent<BoxCollider>().enabled = false;
		anim.StopPlayback();
	}
}
