using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform myTransform;
	private Transform target;
	public Vector3 offset = new Vector3(3f, 7.5f, -3f);
	public Vector3 offsetTemp = new Vector3(0f, 1.75f, -4f);
	private bool applyOffset;
	
	public float moveSpeed = 5f;
	public float returnSpeed = 9f;
	public LayerMask collisionMask;

	void Awake() {
		target = GameObject.Find("Hero").transform;
	}
	void Start () {
		myTransform = this.transform;
	}
	
	void Update () {
		if(target) {
			RaycastHit hit;
			if(Physics.Linecast(target.position,target.position + offset, out hit, collisionMask)) {
				myTransform.position = Vector3.Lerp(transform.position, target.position + offsetTemp, moveSpeed*Time.deltaTime);
				myTransform.LookAt(target.position, Vector3.up);
			} else {
				myTransform.position = Vector3.Lerp(transform.position, target.position + offset, returnSpeed*Time.deltaTime);
				myTransform.LookAt(target.position, Vector3.up); 
			}		
		}		
	}

}
