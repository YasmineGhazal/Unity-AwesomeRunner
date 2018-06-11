using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public GameObject monsterDeadEffect;
	public Transform bullet;
	public float movementSpeedMin = 1f;
	public float movementSpeedMax = 2f;
	public float distanceFromPlayerandStartMove = 20f;	
	public static bool canShoot = false;
	private bool playerInRegion;
	private bool moveRight;
	public float movementSpeed;
	private Transform playerTransform;
	private string FUNCTION_TO_INVOKE = "startShooting";

	void Start () {
		if(Random.Range(0.0f,1.0f)<0.5f)
			moveRight = true;
		else 
			moveRight = false;	

		movementSpeed = Random.Range(movementSpeedMin, movementSpeedMax);
		playerTransform = GameObject.Find(Tags.PLAYER_TAG).transform;
	}
	
	void Update () {	
		if(playerTransform){
			float distanceFromPlayer = (playerTransform.position - transform.position).magnitude;
			if(distanceFromPlayer < distanceFromPlayerandStartMove){
				if(moveRight)
					transform.position = new Vector3(transform.position.x + Time.deltaTime * movementSpeed, transform.position.y, transform.position.z);
				else 
					transform.position = new Vector3(transform.position.x - Time.deltaTime * movementSpeed, transform.position.y, transform.position.z);
			
				if(!playerInRegion){
					if(canShoot)
						InvokeRepeating(FUNCTION_TO_INVOKE, 0.5f, 1.5f);
					playerInRegion = true;	
				}
			} else {
				CancelInvoke(FUNCTION_TO_INVOKE);
			}
		}
	}
	void startShooting(){
		if(playerTransform){
			if(canShoot){
				Vector3 bulletPos = transform.position;
				bulletPos.y += 1.5f;
				bulletPos.x -= 1f;
				Transform newBullet = (Transform) Instantiate(bullet, bulletPos, Quaternion.identity);
				newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1500f);
				newBullet.parent = transform;
			}
		}
	}

	void MonsterDied(){
		Vector3 effectPos = transform.position;
			effectPos.y += 2f;
			Instantiate(monsterDeadEffect, effectPos, Quaternion.identity);
			gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider target){
		if(target.tag == Tags.PLAYER_BULLET){
			gamePlayController.instance.incrementScore(50);
			MonsterDied();	
			}
	}

	void OnCollisionEnter(Collision target){
		if( target.gameObject.tag == Tags.PLAYER_TAG)
			MonsterDied();
	}
}
