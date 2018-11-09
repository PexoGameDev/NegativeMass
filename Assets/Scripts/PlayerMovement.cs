using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float MovementSpeed = 1f;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.W))
		{
			rb.AddForce(new Vector3 (0,0,MovementSpeed));
		}
	}
}
