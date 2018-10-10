using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour {

	public LayerMask enemyLayer;
	public float raduis;
	private bool collided;
	public float damageCount;
	private EnemyHealth attackTarget;
	public GameObject damageEffect;

	void Start () {
		
	}
	
	void Update () {
		Collider[] hits = Physics.OverlapSphere( transform.position, raduis, enemyLayer);
		foreach (Collider c in hits) {
			if(c.isTrigger)
				continue;
			attackTarget = c.gameObject.GetComponent<EnemyHealth>();
			collided = true;
			if(collided) {
				Instantiate(damageEffect, transform.position, transform.rotation);
				attackTarget.enemyTakeDamage(damageCount);
				collided = false;
			}	
		}
	}
}
