using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	// Update is called once per frame
	void Update () {
		
		}


	void OnCollisionEnter2D (Collision2D collision) {
		// Ball does not trigger sound when brick is destoyed.
		// Not 100% sure why, possibly because brick isn't there.
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {	

			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
