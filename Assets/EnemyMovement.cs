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
	BoxCollider myBC;

	void Awake() {
		myRB = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		myAS = GetComponent<AudioSource>();
		myBC = GetComponent<BoxCollider>();
	}

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10f);
	}

	public void StartMove() {
		thePlayer = FindObjectOfType<PlayerController>();	

		dir = (thePlayer.transform.position - transform.position).normalized;
		speed = Random.Range(1f, 5f);
		myRB.velocity = dir * speed;
		//myRB.velocity = new Vector3(dir.x * speed, 0f, 0f);
		Invoke("ContinueMove", Random.Range(1f, 10f));
		Debug.Log("" + dir);
	}

	void ContinueMove() {
		dir = (thePlayer.transform.position - transform.position).normalized;
		speed = Random.Range(1f, 5f);
		myRB.velocity = dir * speed;
		Invoke("ContinueMove", Random.Range(1f, 10f));
		Debug.Log("" + dir);
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
			StartCoroutine(GotHit());
		}
	}

	IEnumerator GotHit() {
		FindObjectOfType<PlayerController>().IncreaseScore();
		myAS.PlayScheduled(0.3);
		myRB.constraints = RigidbodyConstraints.None;
		myRB.AddForce(new Vector3(Random.Range(-150f, 150f), 500f, 200f));
		myRB.AddTorque(100f, Random.Range(-100f, 100f), 50f);
		anim.StopPlayback();
		myBC.enabled = false;
		yield return new WaitForSeconds(2f);
//		myRB.velocity = Vector3.zero;
//		myRB.angularVelocity = Vector3.zero;
//		yield return new WaitForSeconds(0.7f);
//		myRB.AddForce(Vector3.up * -100f);

	}
}
