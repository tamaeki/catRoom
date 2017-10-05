using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

	public float mouseSensitivity = 100f;
	float verticalLimit = 0f;
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis ("Mouse X") * Time.deltaTime * mouseSensitivity;
		float mouseY = Input.GetAxis ("Mouse Y") * Time.deltaTime * mouseSensitivity;

		//transform.Rotate (-mouseY, 0, 0); //rotate up and down for camera
		transform.parent.Rotate(0f, mouseX, 0f); //this will rotate the cube AND the camera b/c the cmaera is parented to the cube

		//new vertical looking up and down code
		verticalLimit -= mouseY;
		verticalLimit = Mathf.Clamp (verticalLimit, -80f, 82f);
		//correct the camera rotation. unroll the camera.
		transform.localEulerAngles = new Vector3 (
			verticalLimit,
			transform.localEulerAngles.y,
			0f);


		//lock the mousecursor
		if (Input.GetMouseButtonDown (0)) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
