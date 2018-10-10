using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {

	private Animator anim;
	private Transform playerTransform;
	private PlayerHealth playerHealth;
	private BossHealth bossHealth;

	private string SKILL1 = "attack1";
	private string SKILL2 = "attack2";
	private string SKILL3 = "attack3";
	private string WALK = "walk";
	private string VICTORY = "victory";		

	void Awake () {

		anim = GetComponent<Animator>();
		bossHealth = GetComponent<BossHealth>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = playerTransform.gameObject.GetComponent<PlayerHealth>();
	}
	
	void Update () {
		if(anim.GetBool(WALK)) 
			transform.Translate (0, 0, 2.5F * Time.deltaTime);
		float distance = Vector3.Distance(transform.position, playerTransform.position);
		if(bossHealth.realHealth > 0) 
			transform.LookAt(playerTransform);
		if(playerHealth.realHealth <= 0) {
			anim.SetBool(SKILL1, false);
			anim.SetBool(SKILL2, false);
			anim.SetBool(SKILL3, false);
			anim.SetBool(WALK, false);
			anim.SetBool(VICTORY, true);
		} else {
			if(distance > 10) {
				anim.SetBool(WALK, true);
				anim.SetBool(SKILL1, false);
				anim.SetBool(SKILL2, false);
				anim.SetBool(SKILL3, false);
			} else {
				if(distance > 5) {
					anim.SetBool(SKILL1, true);	
					anim.SetBool(SKILL3, false);
					anim.SetBool(SKILL2, false);			
				} else if( distance <=5 && distance > 2.5f) {
					anim.SetBool(SKILL2, true);
					anim.SetBool(SKILL1, false);
					anim.SetBool(SKILL3, false);
				} else {
					anim.SetBool(SKILL3, true);
					anim.SetBool(SKILL1, false);
					anim.SetBool(SKILL2, false);
				}
			}
		}
	}

}
