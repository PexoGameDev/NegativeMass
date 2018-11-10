using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField] private GameObject player;
	[SerializeField] private float maxDeltaDistance = 100f;

	private Vector3 velocity = Vector3.zero;
	[SerializeField] private Vector3 offset = new Vector3 (0,10,-100f);
	void Start () {
		
	}
	
	void FixedUpdate () {
		if(Vector3.Distance(player.transform.position,transform.position) > maxDeltaDistance)
		{
			Vector3 targetPos = player.transform.position + offset;
			
		}
	}
}
