using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] private GameObject camera;
	public float CameraRotationSpeed = 1f;
 	public float MovementSpeed = 1f;
	private Rigidbody rb;

	private Vector3 velocity = Vector3.zero;
	private float oldMouseX = 0f;
	private float oldMouseY = 0f;

	void Start () {
		rb = GetComponent<Rigidbody>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		//Screen.lockCursor = true;
		//Cursor.lockState = CursorLockMode.Confined;
	}
	
	void FixedUpdate() {
		Vector3 targetPos = camera.transform.position + new Vector3(0,-20f, 150f);
		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.1f);
	}

	void Update () {
		RotateCamera();

		if(Input.GetKey(KeyCode.W))
			camera.transform.position += camera.transform.forward*MovementSpeed;
		if(Input.GetKey(KeyCode.S))
			camera.transform.position -= camera.transform.forward*MovementSpeed;
		if(Input.GetKey(KeyCode.A))
			camera.transform.position += new Vector3(-1f,0,0) * MovementSpeed;
		if(Input.GetKey(KeyCode.D))
			camera.transform.position += new Vector3(1f,0,0) * MovementSpeed;

	}

	void RotateCamera()
	{
		float mouseX = Input.GetAxis("Mouse X"); //Input.mousePosition.x;
		float mouseY = Input.GetAxis("Mouse Y"); //Input.mousePosition.y;
		
		float verticalMultiplier = 0;
		float horizontalMultiplier = 0;

		if(mouseY > 0.3)
			verticalMultiplier = -1;
		if(mouseY < -0.3)
			verticalMultiplier = 1;

		if(mouseX > 0.3)
			horizontalMultiplier = 1;
		if(mouseX < -0.3)
			horizontalMultiplier = -1;

		float cameraVerticalRotation = verticalMultiplier * CameraRotationSpeed;
		float cameraHorizontalRotation = horizontalMultiplier * CameraRotationSpeed;

		camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(camera.transform.eulerAngles.x + cameraVerticalRotation,camera.transform.eulerAngles.y + cameraHorizontalRotation,0f), CameraRotationSpeed * Time.deltaTime);

		//camera.transform.Rotate(cameraVerticalRotation,cameraHorizontalRotation,0f);
	}
}
