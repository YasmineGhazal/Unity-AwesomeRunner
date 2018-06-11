using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private Transform playerTarget;
	public float offsetZ = -13.5f;
	public float offsetx = 6f;
	public float constantY = 5f;
	public float cameraLerpTime = 0.05f;
	void Awake () {
		playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
	}
	
	void FixedUpdate () {
		if(playerTarget){
			Vector3 targetPos = new Vector3(playerTarget.position.x + offsetx, constantY, playerTarget.position.z + offsetZ);
			transform.position = Vector3.Lerp(transform.position, targetPos, cameraLerpTime);
		}
	}
}
