using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 5f;
	public float jumpPower = 400f;
	public float secondJumpPower = 500f;
	public Transform groundCheckPos;
	public float radius = 0.3f;
	public LayerMask layerGround;
	private Rigidbody myBody;
	private bool isGrounded;
	private bool playerJumped;
	private bool canDoubleJump;
	private PlayerAnimation playerAnim;
	public GameObject smokePosition;
	private bool gameStarted;
	private BGScroller bgScroller;

	private Button jumpBtn;

	void Awake () {
		myBody = GetComponent<Rigidbody>();
		playerAnim = GetComponent<PlayerAnimation>();
		bgScroller = GameObject.Find(Tags.BG).GetComponent<BGScroller>();
		jumpBtn = GameObject.Find(Tags.JUMP_BTN).GetComponent<Button>();	
		jumpBtn.onClick.AddListener( () => playerJump());

	}

	void Start (){
		StartCoroutine (startGame());
	}

	void FixedUpdate () {
		if(gameStarted) {
			playerMove();
			playerGrounded();
		}
	}

	void playerMove (){
		myBody.velocity = new Vector3(movementSpeed, myBody.velocity.y, 0f);
	}

	void playerGrounded (){
		isGrounded = Physics.OverlapSphere(groundCheckPos.position, radius, layerGround).Length > 0 ;
	}

	void playerJump (){
		if(isGrounded){
			playerAnim.didJump();
			myBody.AddForce(new Vector3(0, jumpPower, 0));
			canDoubleJump = true;
			playerJumped = true;
		}else if( canDoubleJump ){
			canDoubleJump = false;
			myBody.AddForce(new Vector3(0, secondJumpPower, 0));
		}  
	}

	IEnumerator startGame() {
		yield return new WaitForSeconds(2f);
		gameStarted = true;
		gamePlayController.instance.canIncrementScore = true;
		bgScroller.canScroll = true;
		PlayerHealthDamageShoot.canShoot = true;
		smokePosition.SetActive(true);
		Monster.canShoot = true;
		playerAnim.playerRun();
	}

	void OnCollisionEnter(Collision target) {
		if(target.gameObject.tag == Tags.PLATFORM_TAG){
			if( playerJumped ){
				playerJumped = false;
				playerAnim.didLand();	
			}
		}
	}
}
