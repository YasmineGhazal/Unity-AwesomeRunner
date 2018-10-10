using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {

	private SphereCollider col;
	private BossAI bossAI;
	private GameObject bossHealth;
	void Awake () {
		col = GetComponent<SphereCollider>();
		bossAI = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAI>();
		bossHealth = GameObject.Find("TrollBackgroundHealth");

	}
	
	void OnTriggerEnter (Collider target) {
		if(target.tag == "Player") {
			bossAI.enabled = true;
			bossHealth.SetActive(true);
			col.enabled = false;
		}
	}
}
