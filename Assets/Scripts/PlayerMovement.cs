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
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0,-10f, 150f), 0.1f);
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
		float mouseX = Input.GetAxis("Mouse X"); 
		float mouseY = Input.GetAxis("Mouse Y"); 
		
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

		verticalMultiplier *= CameraRotationSpeed;
		horizontalMultiplier *= CameraRotationSpeed;

		camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(camera.transform.eulerAngles.x + verticalMultiplier,camera.transform.eulerAngles.y + horizontalMultiplier,0f), CameraRotationSpeed * Time.deltaTime);
	}
}
