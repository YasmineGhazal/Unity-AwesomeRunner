using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour {

	public GameObject skill3;
	public GameObject skill3Point;

	public AudioClip earthHit;
	private AudioSource audioSource;

	public GameObject skill1;
	public GameObject skill1Ponit1;
	public GameObject skill1Ponit2;
	public GameObject skill1Ponit3;
	public GameObject skill1Ponit4;
	public GameObject skill1Ponit5;
	public GameObject skill1Ponit6;
	public GameObject skill1Ponit7;
	public GameObject skill1Ponit8;
	public GameObject skill1Ponit9;
	public GameObject skill1Ponit10;
	public GameObject skill1Ponit11;
	public GameObject skill1Ponit12;
	public GameObject skill1Ponit13;
	public GameObject skill1Ponit14;

	public GameObject hitPoint1;
	public GameObject hitPoint2;
	
	void Awake () {
		audioSource = GetComponent<AudioSource>();
	}

	void skillOne() {
		Instantiate(skill1, skill1Ponit1.transform.position, skill1Ponit1.transform.rotation);
		Instantiate(skill1, skill1Ponit2.transform.position, skill1Ponit2.transform.rotation);
		Instantiate(skill1, skill1Ponit3.transform.position, skill1Ponit3.transform.rotation);
		Instantiate(skill1, skill1Ponit4.transform.position, skill1Ponit4.transform.rotation);
		Instantiate(skill1, skill1Ponit5.transform.position, skill1Ponit5.transform.rotation);
		Instantiate(skill1, skill1Ponit6.transform.position, skill1Ponit6.transform.rotation);
		Instantiate(skill1, skill1Ponit7.transform.position, skill1Ponit7.transform.rotation);
		Instantiate(skill1, skill1Ponit8.transform.position, skill1Ponit8.transform.rotation);
		Instantiate(skill1, skill1Ponit9.transform.position, skill1Ponit9.transform.rotation);
		Instantiate(skill1, skill1Ponit10.transform.position, skill1Ponit10.transform.rotation);
		Instantiate(skill1, skill1Ponit11.transform.position, skill1Ponit11.transform.rotation);
		Instantiate(skill1, skill1Ponit12.transform.position, skill1Ponit12.transform.rotation);
		Instantiate(skill1, skill1Ponit13.transform.position, skill1Ponit13.transform.rotation);
		Instantiate(skill1, skill1Ponit14.transform.position, skill1Ponit14.transform.rotation);	
		StartCoroutine(skill1AfterWait());
		
	}

	void skillThree() {
		Instantiate(skill3, skill3Point.transform.position, skill3Point.transform.rotation);
		audioSource.PlayOneShot(earthHit);
	}

	void PunchRight() {
		hitPoint2.SetActive(true);
	}

	void endPunchRight() {
		hitPoint2.SetActive(false);
	}

	IEnumerator skill1AfterWait() {
		yield return new WaitForSeconds(1f);
		Instantiate(skill1, skill1Ponit1.transform.position, skill1Ponit1.transform.rotation);
		Instantiate(skill1, skill1Ponit2.transform.position, skill1Ponit2.transform.rotation);
		Instantiate(skill1, skill1Ponit3.transform.position, skill1Ponit3.transform.rotation);
		Instantiate(skill1, skill1Ponit4.transform.position, skill1Ponit4.transform.rotation);
		Instantiate(skill1, skill1Ponit5.transform.position, skill1Ponit5.transform.rotation);
		Instantiate(skill1, skill1Ponit6.transform.position, skill1Ponit6.transform.rotation);
		Instantiate(skill1, skill1Ponit7.transform.position, skill1Ponit7.transform.rotation);
		Instantiate(skill1, skill1Ponit8.transform.position, skill1Ponit8.transform.rotation);
		Instantiate(skill1, skill1Ponit9.transform.position, skill1Ponit9.transform.rotation);
		Instantiate(skill1, skill1Ponit10.transform.position, skill1Ponit10.transform.rotation);
		Instantiate(skill1, skill1Ponit11.transform.position, skill1Ponit11.transform.rotation);
		Instantiate(skill1, skill1Ponit12.transform.position, skill1Ponit12.transform.rotation);
		Instantiate(skill1, skill1Ponit13.transform.position, skill1Ponit13.transform.rotation);
		Instantiate(skill1, skill1Ponit14.transform.position, skill1Ponit14.transform.rotation);	

	}

}
