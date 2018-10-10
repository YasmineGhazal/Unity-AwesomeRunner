using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float realHealth;
	private bool playerDead;
	
	private Slider healthSlider;
	private Text healthText;

	private BossHealth bossHealth;
	private Transform bossTransform;
	private GameObject boss;

	private GameObject winner;
	private GameObject tryAgain;

	private Animator anim;

	public static int destroyedCount;

	void Awake () {

		destroyedCount = 0 ;
		anim = GetComponent<Animator>();
		healthSlider = GameObject.Find("HeroBackgroundHealth").GetComponentInChildren<Slider>();
		healthText = GameObject.Find("HeroBackgroundHealth").GetComponentInChildren<Text>();

		healthText.text = realHealth.ToString();
		healthSlider.value = realHealth;
		winner = GameObject.Find("winner");
		winner.SetActive(false);
		tryAgain = GameObject.Find("tryAgain");
		tryAgain.SetActive(false);

		bossTransform = GameObject.FindGameObjectWithTag("Boss").transform;
		bossHealth = bossTransform.gameObject.GetComponent<BossHealth>();

	}
	void Start() {
		boss = GameObject.FindGameObjectWithTag("Boss");
		boss.SetActive(false);
	 }
	
	void Update () {
		if(realHealth <= 0) {
			realHealth = 0;
			anim.SetBool("attack1",false);
			anim.SetBool("attack2",false);
			anim.SetBool("attack3",false);
			anim.SetBool("attack4",false);
			anim.SetBool("walk",false);
			tryAgain.SetActive(true);
			StartCoroutine(backToMain());
		}
		if(realHealth > 100) {
			realHealth = 100;
		}
		if(bossHealth.realHealth <= 0){
			winner.SetActive(true);
			StartCoroutine(backToMain());
		}
		if(destroyedCount >= 10) {
			boss.SetActive(true);
			destroyedCount-=100;
		}
	}

	public void takeDamage(float amount) {
		realHealth -= amount;
		if(realHealth <= 0) {
			realHealth = 0;
		}
		if(amount > 0) {
			healthText.text = ((int)realHealth).ToString();
			healthSlider.value = realHealth;
		}
	}

	IEnumerator backToMain() {
		yield return new WaitForSeconds(4);
		SceneManager.LoadScene("mainMenu");
	}

	public void pickUpHealthBox(float amount) {
		realHealth += amount;
		if(realHealth > 100)
			realHealth = 100;
		healthText.text = ((int)realHealth).ToString();
		healthSlider.value = realHealth;
	}
}
