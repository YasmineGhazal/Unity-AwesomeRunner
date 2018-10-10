using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

	public float realHealth;
	public AudioClip dead;
	public AudioClip getHit;
	private AudioSource audioSource;
	
	private Animator anim;
	private CapsuleCollider col;

	private Slider healthSlider;
	private Text healthText;
	
	private string DEAD = "dead";
	private string GETHIT = "getHit";

	void Awake () {
		anim = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource>();
		col = GetComponent<CapsuleCollider>();
		healthSlider = GameObject.Find("TrollBackgroundHealth").GetComponentInChildren<Slider>();
		healthText = GameObject.Find("TrollBackgroundHealth").GetComponentInChildren<Text>();
		GameObject.Find("TrollBackgroundHealth").SetActive(false);
		healthText.text = realHealth.ToString();
		healthSlider.value = realHealth;

	}

	void bossDie() {
		anim.SetBool(DEAD, true);
		audioSource.PlayOneShot(dead);
		col.enabled = false;
		StartCoroutine(stopDeadAnimtion());
	}

	void bossGetHit() {
		if(realHealth == 200) 
			GameObject.Find("TrollBackgroundHealth").SetActive(true);
		anim.SetBool(GETHIT, true);
		audioSource.PlayOneShot(getHit);
		StartCoroutine (stopGetHitAnimtion());
	}

	public void takeDamage(float amount) {
		realHealth -=amount;
		 
		if(realHealth <= 0) {
			realHealth = 0 ;
			bossDie();
		} else 
			bossGetHit();
		healthText.text = realHealth.ToString();
		healthSlider.value = realHealth;
		
	}

	IEnumerator stopDeadAnimtion() {
		yield return new WaitForSeconds(1f);
		anim.SetBool(DEAD, false);
		Destroy(gameObject);
	}

	IEnumerator stopGetHitAnimtion() {
		yield return new WaitForSeconds(.5f);
		anim.SetBool(GETHIT, false);
	}
}
