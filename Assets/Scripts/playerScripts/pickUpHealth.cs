using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpHealth : MonoBehaviour {

	private PlayerHealth playerHealth;
	public float amount;
	private AudioSource audioSource;
	public AudioClip takeHealth;
	private Vector3 position1 ;
	private Vector3 position2 ;
	
	void Awake() {
		playerHealth = GameObject.Find("Hero").GetComponent<PlayerHealth>();
		audioSource = GameObject.Find("Hero").GetComponent<AudioSource>();
	}

	void Update() {
		transform.Rotate(0,0,3);
	}

	void OnTriggerEnter(Collider target) {
		if(target.tag == "Player") {
			if(playerHealth.realHealth<100) {
				playerHealth.pickUpHealthBox(amount);
				audioSource.PlayOneShot(takeHealth);
				Destroy(gameObject);
			}
		}	
	}

 }
