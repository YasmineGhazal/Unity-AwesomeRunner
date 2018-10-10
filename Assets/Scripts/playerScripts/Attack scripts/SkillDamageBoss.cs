using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamageBoss : MonoBehaviour {

	public LayerMask bossLayer;
	public float radius;
	public float damageCount;
	public GameObject damageEffect;
	private BossHealth bossHealth;

	void Awake () {
		Collider[] hits = Physics.OverlapSphere (transform.position, radius, bossLayer);

		foreach(Collider c in hits) {
			if(c.isTrigger)
				continue;
			bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();
			Instantiate(damageEffect, transform.position, transform.rotation);
			bossHealth.takeDamage(damageCount);	
		}
	}
	
	void Update () {
		
	}
}
