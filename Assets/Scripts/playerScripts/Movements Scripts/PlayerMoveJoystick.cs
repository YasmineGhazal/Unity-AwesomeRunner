using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour {
/* 
	public SimpleTouchController leftController;
	public Transform headTrans;
	public float speedMovements = 5f;
	public float speedContinuousLook = 100f;
	public float speedProgressiveLook = 3000f;
	public float turningSmoothing = 0.3f;

	private Transform playerTransform;
	private Rigidbody myBody;
	private Quaternion screenMovmentSpace;
	private Vector3 screenMovementForward;
	private Vector3 screenMovementRight;
	private Animator anim;

	public Vector3 movementDirection;
	private string ANIMATION_WALK = "walk";
	
	
	void Awake () {
		anim = GetComponent<Animator>();
		playerTransform = this.transform;
		myBody = GetComponent<Rigidbody>();
		movementDirection = Vector2.zero;
	}
	 void Start() {
		screenMovmentSpace = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y, 0);
		screenMovementForward = screenMovmentSpace * Vector3.forward;
		screenMovementRight = screenMovmentSpace * Vector3.right;
	 }
	void FixedUpdate()
   {
         if(myBody.velocity.magnitude > speedMovements) {
                myBody.velocity = myBody.velocity.normalized * speedMovements;
         }
   }
	void Update () {
       movementDirection = leftController.GetTouchPosition.x * screenMovementRight * 45 +
								  leftController.GetTouchPosition.y * screenMovementForward * 45;
		if( movementDirection.sqrMagnitude > 1)
			movementDirection.Normalize();						  
        if (leftController.GetTouchPosition.x != 0 && leftController.GetTouchPosition.y !=00 && anim.GetBool("attack1") == false && anim.GetBool("attack3") == false && anim.GetBool("attack4") == false) {
			Vector3 moveVector = ((transform.position + (transform.forward * leftController.GetTouchPosition.y * Time.deltaTime * speedMovements) +
			(transform.right * leftController.GetTouchPosition.x * Time.deltaTime * speedMovements)));
			anim.SetBool(ANIMATION_WALK, true);
			myBody.MovePosition(moveVector);
			Vector3 faceDirection = movementDirection;
			if(faceDirection == Vector3.zero) {
				//myBody.angularVelocity = Vector3.zero;
			} else {
				float rotationAngle = angleAroundAxis(transform.forward, faceDirection, Vector3.up);
				//myBody.angularVelocity = Vector3.up * rotationAngle * turningSmoothing;
			}
			//playerTransform.Rotate(new Vector3(0 ,transform.rotation.y + leftController.GetTouchPosition.y*10 ,0 ));
			//myBody.AddForce(moveVector * speedMovements *10 , ForceMode.Acceleration);
        }  else {
			anim.SetBool(ANIMATION_WALK, false);
		}
	}

	float angleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis) {
		dirA = dirA - Vector3.Project(dirA, axis);
		dirB = dirB - Vector3.Project(dirB, axis);
		
		float angle = Vector3.Angle(dirA, dirB);

		return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) > 0 ? 1 :-1);
	}	
*/

private Animator anim;
	public Transform playerTransform;
	private Quaternion screenMovmentSpace;
	private Vector3 screenMovementForward;
	private Vector3 screenMovementRight;
	
	[HideInInspector]
	public Vector3 movementDirection;
	public SimpleTouchController leftController;
	private Rigidbody myBody;
	public float walkingSpeed = 5f;
	public float walkingSnapyness = 50f;
	public float turningSmoothing = 0.3f;

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
		movementDirection = leftController.GetTouchPosition.x * screenMovementRight +
								  leftController.GetTouchPosition.y * screenMovementForward;
		if( leftController.GetTouchPosition.x != 0 || leftController.GetTouchPosition.y != 0 ) {
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
		if (leftController.GetTouchPosition.x != 0 && leftController.GetTouchPosition.y !=00 
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
