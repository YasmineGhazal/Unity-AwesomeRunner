using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour {

	public LayerMask enemyLayer;
	public float raduis;
	public GameObject attackEffect;
	public float damageCount;

	private EnemyHealth enemyHealth;
	private bool collided;

	void Start () {
		
	}
	
	void Update () {
		Collider [] hits = Physics.OverlapSphere(transform.position, raduis, enemyLayer);

		foreach(Collider c in hits) {
			if(c.isTrigger)	
				continue;
			collided = true;
			enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
			if(collided) {
				Instantiate (attackEffect, transform.position, transform.rotation);
				collided = false;
				enemyHealth.enemyTakeDamage(damageCount);
				Destroy(gameObject);
		}
		}

		
	}
}
