using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float realHealth;
	private AudioSource audioSource;
	public AudioClip enemyDeadSound;

	private Animator anim;
	private bool enemyDead;
	private bool enemyGetHit;

	public GameObject deadEffect;
	public Transform deadEffecPoint;
	public GameObject attackPoint1;
	public GameObject attackPoint2;

	private string ATTACK = "attack";
	private string GETHIT = "getHit";
	private string DEAD = "dead";

	void Awake () {
		audioSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		if(enemyDead) {
			dead();
		}
		if(enemyGetHit) {
			attacked();
		}
	}

	void enemyDying() {
		anim.SetBool(DEAD, true);
		anim.SetBool(GETHIT, false);
		enemyDead = true;
		StartCoroutine (DeadEffect());
		attackPoint1.SetActive(false);
		attackPoint2.SetActive(false);
		audioSource.PlayOneShot(enemyDeadSound);	
	}

	void dead() {
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Dead")) {
			anim.SetBool(DEAD, false);
		}
	}

	public void enemyTakeDamage(float amount) {
		realHealth -=amount;
		if(realHealth <= 0) {
			realHealth = 0;
			PlayerHealth.destroyedCount++;
			enemyDying();
		}

		if(amount > 0) 
			enemyGetHit = true;

	}

	void attacked() {
		enemyGetHit = false;
		anim.SetBool(GETHIT, true);
		anim.SetBool(ATTACK, false);
		transform.Translate(Vector3.back * .5f);
		StartCoroutine(stopGetHit());
	}

	IEnumerator DeadEffect() {
		yield return new WaitForSeconds(2f);
		Instantiate(deadEffect, deadEffecPoint.position, deadEffecPoint.rotation);
		Destroy(gameObject);
	}

	IEnumerator stopGetHit() {
		yield return new WaitForSeconds(.25f);
		anim.SetBool(GETHIT, false);
		anim.SetBool(ATTACK, true);
	}
}
