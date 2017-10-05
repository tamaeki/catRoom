using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
	Rigidbody rb;
	Vector3 inputVector;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxis ("Horizontal"); //a/d/left/right arrows
		float verticalInput = Input.GetAxis ("Vertical"); //w/s/up/down arrows

		//transform our input values based on this transforms right and forward directions
		inputVector = transform.right * horizontalInput + transform.forward * verticalInput;

		//normalizes input vector so diagonal movement isnt faster
		if (inputVector.magnitude > 1f) {
			inputVector = Vector3.Normalize (inputVector);
		}
	}

	void FixedUpdate(){
		GetComponent<Rigidbody> ().velocity = inputVector * 25f + Physics.gravity * .9f;
	}
}
