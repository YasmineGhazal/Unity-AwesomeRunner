using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBossCollision : MonoBehaviour {

	public LayerMask bossLayer;
	public float radius;
	public GameObject attackEffect;
	public float damageCount;
	private BossHealth bossHealth;

	void Awake () {
		Collider[] hits = Physics.OverlapSphere(transform.position, radius, bossLayer);

		foreach(Collider c in hits) {
			if(c.isTrigger)
				continue;
			bossHealth = c.gameObject.GetComponent<BossHealth>();
			Instantiate(attackEffect, transform.position, transform.rotation);
			bossHealth.takeDamage(damageCount);
		}
	}

}
