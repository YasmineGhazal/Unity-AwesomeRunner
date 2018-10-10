using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour {

	private Animator anim;
	public Transform playerTransform;
	private Quaternion screenMovmentSpace;
	private Vector3 screenMovementForward;
	private Vector3 screenMovementRight;
	
	[HideInInspector]
	public Vector3 movementDirection;
	private Rigidbody myBody;
	public float walkingSpeed = 5f;
	public float walkingSnapyness = 50f;
	public float turningSmoothing = 0.3f;

	private string AXIS_Y = "Vertical";
	private string AXIS_X = "Horizontal";
	private string ANIMATION_WALK = "walk";
	void Awake () {
		anim = GetComponent<Animator>();
		movementDirection = Vector2.zero;
		myBody = GetComponent<Rigidbody>();
	}
	
	void Start () {
		screenMovmentSpace = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y, 0);
		screenMovementForward = screenMovmentSpace * Vector3.forward;
		screenMovementRight = screenMovmentSpace * Vector3.right;
	}

	void Update () {
		movementDirection = Input.GetAxis(AXIS_X) * screenMovementRight +
								  Input.GetAxis(AXIS_Y) * screenMovementForward;
		if( Input.GetAxis(AXIS_X) != 0 || Input.GetAxis(AXIS_Y) != 0 ) {
			anim.SetBool( ANIMATION_WALK, true);
		} else {
			anim.SetBool( ANIMATION_WALK, false);
		}
		if( movementDirection.sqrMagnitude > 1){
			movementDirection.Normalize();
		}
		}
	void FixedUpdate () {
		Vector3 targetVelocity = movementDirection * walkingSpeed;
		Vector3 deltaVelocity = targetVelocity - myBody.velocity;

		if(myBody.useGravity) {
			deltaVelocity.y = 0f;
		}
		if(( Input.GetAxis(AXIS_X) != 0 || Input.GetAxis(AXIS_Y) != 0 ) 
			&& anim.GetBool("attack1") == false &&
			 anim.GetBool("attack3") == false && anim.GetBool("attack4") == false) {
		myBody.AddForce(deltaVelocity * walkingSnapyness, ForceMode.Acceleration);
		Vector3 faceDirection = movementDirection;
		if(faceDirection == Vector3.zero) {
			myBody.angularVelocity = Vector3.zero;
		} else {
			float rotationAngle = angleAroundAxis(transform.forward, faceDirection, Vector3.up);
			myBody.angularVelocity = Vector3.up * rotationAngle * turningSmoothing;
		}
		 }	
	}

	float angleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis) {
		dirA = dirA - Vector3.Project(dirA, axis);
		dirB = dirB - Vector3.Project(dirB, axis);
		
		float angle = Vector3.Angle(dirA, dirB);

		return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) > 0 ? 1 :-1);
	}	
}
