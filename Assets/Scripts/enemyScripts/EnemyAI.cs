using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour {

	private Transform enemyTransform;
	public float chaseSpeed;
	private CapsuleCollider capCol;
	private Transform player;
	private Animator anim;
	private EnemyHealth enemyHealth;
	private PlayerHealth playerHealth;
	private bool victory;

	//animation states
	private string ATTACK = "attack";
	private string RUN = "run";
	private string SPEED = "speed";
	private string VICTORY="victory";

	private NavMeshAgent navAgent;
	public Transform[] navPoints;
	private int navIndex;

	void Awake () {

		capCol = GetComponent<CapsuleCollider>();
		anim = GetComponent<Animator>();
		player = GameObject.Find("Hero").transform;
		enemyTransform = this.transform;
		enemyHealth = GetComponent<EnemyHealth>();
		playerHealth = player.gameObject.GetComponent<PlayerHealth>();
		navAgent = GetComponent<NavMeshAgent>();
		navIndex = Random.Range(0, navPoints.Length);
		navAgent.SetDestination(navPoints[navIndex].position);

	}
	
	void Update () {
		float distance = Vector3.Distance(enemyTransform.position, player.position);
		if(enemyHealth.realHealth > 0 ){
			if(distance > 13 ) {
				search();
			} else {
				if(distance < 2)
					attack();	
				else 
					chase();
				transform.LookAt(player);
			}
		}
		if(enemyHealth.realHealth <= 0) 
			capCol.enabled = false;
		if(!victory && playerHealth.realHealth <= 0)	
				enemyVictory();	
		if(victory) {
			StartCoroutine (stopVictoryAnimation());
		}
			
	}

	void search() {
		anim.SetBool(RUN, true);
		if(navAgent.remainingDistance <= 0.5f) {
			anim.SetFloat(SPEED, 0);
			if(navIndex == navPoints.Length -1) 
				navIndex = 0;
			else 
				navIndex++;
			navAgent.SetDestination(navPoints[navIndex].position);		
		} else {
			anim.SetFloat(SPEED, 7);
		}
		

	}

	void chase() {
		navAgent.SetDestination(player.position);
		anim.SetBool(RUN , true);
		anim.SetBool(ATTACK, false);
	}

	void attack() {
		anim.SetBool(ATTACK, true);
	}

	void enemyVictory() {
		anim.SetBool(RUN, false);
		anim.SetBool(ATTACK, false);
		navAgent.isStopped = true;
		anim.SetBool(VICTORY, true);
		victory = true;
	}

	IEnumerator stopVictoryAnimation() {
		yield return new WaitForSeconds(.25f);
		anim.SetBool(VICTORY, false);
	}

}
