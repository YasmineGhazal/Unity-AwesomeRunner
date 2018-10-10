using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour {

	public GameObject skillOneEffectPrefab;
	public GameObject skillOneDamagePrefab;
	public Transform skillOnePoint;
	public Transform skillOnePoint_1;
	public Transform skillOnePoint_2;
	public Transform skillOnePoint_3;
	public Transform skillOnePoint_4;
	public Transform skillOnePoint_5;
	public Transform skillOnePoint_6;
	public Transform skillOnePoint_7;
	public Transform skillOnePoint_8;

	public GameObject skillTwoEffectPrefab;
	public GameObject skillTwoDamagePrefab;
	public Transform skillTwoPoint;
	public Transform skillTwoPoint_1;
	public Transform skillTwoPoint_2;
	public Transform skillTwoPoint_3;
	public Transform skillTwoPoint_4;
	public Transform skillTwoPoint_5;
	public Transform skillTwoPoint_6;

	public GameObject skillThreeEffect1;
	public GameObject skillThreeEffect2;
	public GameObject skillThreeEffect3;
	public GameObject skillThreeEffect4;
	public GameObject skillThreeEffect5;
	public GameObject skillThreeEffect6;
	public GameObject skillThreeEffect7;
	public GameObject skillThreeEffect8;
	public Transform skillThreePoint_1;
	public Transform skillThreePoint_2;
	public Transform skillThreePoint_3;
	public Transform skillThreePoint_4;
	public Transform skillThreePoint_5;
	public Transform skillThreePoint_6;
	public Transform skillThreePoint_7;
	public Transform skillThreePoint_8;		

	private Animator anim;
	private string ANIMATION_ATTACK = "attack2";
	private string ANIMATION_ATTACK1 = "attack1";
	private string ANIMATION_ATTACK3 = "attack3";
	private string ANIMATION_ATTACK4 = "attack4";
	
	public GameObject powerBall;
	public GameObject powerBallPos;
	public Transform powerBallTarget;
	public AudioSource audioSource;
	public AudioClip whoosh;
	public AudioClip electric2;	
	public AudioClip skillOneMusic1;
	public AudioClip skillOneMusic2;
	public AudioClip playerSkillOneSound;		
	public AudioClip skillTwoMusic;	
	public AudioClip skillThreeMusic;	

	//private bool s1NotUsed;
	//private bool s2NotUsed;
	//private bool s3NotUsed;

	private Button skill1Btn;
	private Button skill2Btn;
	private Button skill3Btn;
		
	private Vector3 powerBallForce;
	void Awake () {
		anim = GetComponent<Animator>();
	//	s1NotUsed = true;
	//	s2NotUsed = true;
	//	s3NotUsed = true;

		skill3Btn = GameObject.Find("fireballsBtn").GetComponent<Button>();
		skill2Btn = GameObject.Find("deathcircleBtn").GetComponent<Button>();
		skill1Btn = GameObject.Find("thunderBtn").GetComponent<Button>();

		skill1Btn.onClick.AddListener( () => skill1BtnPressed() );
		skill2Btn.onClick.AddListener( () => skill2BtnPressed() );
		skill3Btn.onClick.AddListener( () => skill3BtnPressed() );

	}
	
	/*void Update () {
		handleButtonPresses();
	}
	*/
	public void attackBtnPressed() {
		anim.SetBool(ANIMATION_ATTACK, true);	
	}

	public void attackBtnReleased() {
		anim.SetBool(ANIMATION_ATTACK, false);
	}

	public void skill1BtnPressed() {
		anim.SetBool(ANIMATION_ATTACK1, true);
	}

	public void skill2BtnPressed() {
		anim.SetBool(ANIMATION_ATTACK3, true);
	}

	public void skill3BtnPressed() {
		anim.SetBool(ANIMATION_ATTACK4, true);
	}

	/*void handleButtonPresses() {
		if(Input.GetKeyDown(KeyCode.I)) {
			anim.SetBool(ANIMATION_ATTACK, true);			
		}
		if(Input.GetKeyUp(KeyCode.I)) {
			anim.SetBool(ANIMATION_ATTACK, false);
		}
		if(Input.GetKeyDown(KeyCode.J)) {
			if(s1NotUsed){
				s1NotUsed = false ;
				anim.SetBool(ANIMATION_ATTACK1, true);
				StartCoroutine(resetSkills(1));
			}
		}
		if(Input.GetKeyDown(KeyCode.K)) {
			if(s2NotUsed) {
				s2NotUsed = false ;
				anim.SetBool(ANIMATION_ATTACK3, true);
				StartCoroutine(resetSkills(2));
			}
		}
		if(Input.GetKeyDown(KeyCode.L)) {
			if(s3NotUsed) {
				s3NotUsed = false ;
				anim.SetBool(ANIMATION_ATTACK4, true);
				StartCoroutine(resetSkills(3));
			}
		}
	}*/

	public void startPowerBall() {
		powerBall.transform.position = new Vector3(powerBallPos.transform.position.x, 
				powerBallPos.transform.position.y, powerBallPos.transform.position.z);
		audioSource.volume = .5f;
		audioSource.PlayOneShot(electric2);
		StartCoroutine(stopSoundClip(1.5f));
		GameObject temp = Instantiate (powerBall, powerBallPos.transform.position, powerBallPos.transform.rotation);
		temp.SetActive(true);
		temp.transform.LookAt(powerBallTarget);
		temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward*75,ForceMode.Acceleration);
		Destroy(temp,3);
	}

	IEnumerator stopSoundClip(float timer) {
		yield return new WaitForSeconds(timer);
		audioSource.Stop();
	}
	public void startMoveingHands() {
		audioSource.volume = 1f;
		audioSource.PlayOneShot(whoosh);
	}

	void skillOne() {
		Instantiate(skillOneEffectPrefab, skillOnePoint.position, skillOnePoint.rotation);
		audioSource.PlayOneShot(skillOneMusic1);
		StartCoroutine(skillOneCoroutine());
	}

	void skillOneSound(){
		audioSource.PlayOneShot(playerSkillOneSound);
	}

	void skillOneEnd() {
		anim.SetBool(ANIMATION_ATTACK1, false);
	}

	IEnumerator skillOneCoroutine() {
		yield return new WaitForSeconds(1.5f);
		Instantiate(skillOneDamagePrefab, skillOnePoint_1.position, skillOnePoint_1.rotation);
		Instantiate(skillOneDamagePrefab, skillOnePoint_2.position, skillOnePoint_2.rotation);
		Instantiate(skillOneDamagePrefab, skillOnePoint_3.position, skillOnePoint_3.rotation);
		Instantiate(skillOneDamagePrefab, skillOnePoint_4.position, skillOnePoint_4.rotation);
		Instantiate(skillOneDamagePrefab, skillOnePoint_5.position, skillOnePoint_5.rotation);
		Instantiate(skillOneDamagePrefab, skillOnePoint_6.position, skillOnePoint_6.rotation);
		Instantiate(skillOneDamagePrefab, skillOnePoint_7.position, skillOnePoint_7.rotation);
		Instantiate(skillOneDamagePrefab, skillOnePoint_8.position, skillOnePoint_8.rotation);
	}

	void skillTwo() {
		Instantiate(skillTwoEffectPrefab, skillTwoPoint.position, skillTwoPoint.rotation);
		audioSource.PlayOneShot(skillTwoMusic);
		StartCoroutine(skillTwoCoroutine());
	}

	void skillTwoEnd() {
		anim.SetBool(ANIMATION_ATTACK3, false);
	}

	IEnumerator skillTwoCoroutine() {
		yield return new WaitForSeconds(1.5f);
		Instantiate(skillTwoDamagePrefab, skillTwoPoint_1.position, skillTwoPoint_1.rotation);
		Instantiate(skillTwoDamagePrefab, skillTwoPoint_2.position, skillTwoPoint_2.rotation);
		Instantiate(skillTwoDamagePrefab, skillTwoPoint_3.position, skillTwoPoint_3.rotation);
		Instantiate(skillTwoDamagePrefab, skillTwoPoint_4.position, skillTwoPoint_4.rotation);
		Instantiate(skillTwoDamagePrefab, skillTwoPoint_5.position, skillTwoPoint_5.rotation);
		Instantiate(skillTwoDamagePrefab, skillTwoPoint_6.position, skillTwoPoint_6.rotation);
	}

	void skillThree() {
		GameObject fireBall1 = Instantiate(skillThreeEffect1, skillThreePoint_1.position,skillThreePoint_1.rotation);
		fireBall1.SetActive(true);
		Destroy(fireBall1, 2);
		GameObject fireBall2 = Instantiate(skillThreeEffect2, skillThreePoint_2.position,skillThreePoint_2.rotation);
		fireBall2.SetActive(true);
		Destroy(fireBall2, 2);
		GameObject fireBall3 = Instantiate(skillThreeEffect3, skillThreePoint_3.position,skillThreePoint_3.rotation);
		fireBall3.SetActive(true);
		Destroy(fireBall3, 2);		
		GameObject fireBall4 = Instantiate(skillThreeEffect4, skillThreePoint_4.position,skillThreePoint_4.rotation);
		fireBall4.SetActive(true);
		Destroy(fireBall4, 2);
		GameObject fireBall5 = Instantiate(skillThreeEffect5, skillThreePoint_5.position,skillThreePoint_5.rotation);
		fireBall5.SetActive(true);
		Destroy(fireBall5, 2);
		GameObject fireBall6 = Instantiate(skillThreeEffect6, skillThreePoint_6.position,skillThreePoint_6.rotation);
		fireBall6.SetActive(true);
		Destroy(fireBall6, 2);
		GameObject fireBall7 = Instantiate(skillThreeEffect7, skillThreePoint_7.position,skillThreePoint_7.rotation);
		fireBall7.SetActive(true);
		Destroy(fireBall7, 2);
		GameObject fireBall8 = Instantiate(skillThreeEffect8, skillThreePoint_8.position,skillThreePoint_8.rotation);
		fireBall8.SetActive(true);
		Destroy(fireBall8, 2);
	}

	void skillThreeEnd() {
		anim.SetBool(ANIMATION_ATTACK4, false);
	}

	/*IEnumerator resetSkills(int n) {
		yield return new WaitForSeconds(5f);
		switch(n) {
			case 1 :
				s1NotUsed = true;
				break;
			case 2 :
				s2NotUsed = true;
				break;
			case 3 :
				s3NotUsed = true;
				break;	
		}		
	} */
}