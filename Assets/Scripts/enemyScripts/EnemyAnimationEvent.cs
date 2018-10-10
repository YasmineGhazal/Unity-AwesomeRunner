using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour {

	public GameObject attackPoint1;
	public GameObject attackPoint2;
	public GameObject enemyAttackEffect;
	
	void enemyAttack1() {
			Instantiate (enemyAttackEffect, attackPoint1.transform.position, attackPoint1.transform.rotation);
	}

	void enemyAttack2() {
			Instantiate (enemyAttackEffect, attackPoint2.transform.position, attackPoint2.transform.rotation);
	}

	void enemyAttack1Start() {
			attackPoint1.SetActive(true);
	}

	void enemyAttack1End() {
			attackPoint1.SetActive(false);
	}

	void enemyAttack2Start() {	
			attackPoint2.SetActive(true);
	}

	void enemyAttack2End() {
			attackPoint2.SetActive(false);
	}
}
