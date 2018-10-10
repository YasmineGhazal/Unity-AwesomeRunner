using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitBeforeAttack : MonoBehaviour {

	public int waitTime;
	private int fadeTime;
	private Text waitText;
	private Image fadeImg;
	private bool canFade;
	private GameObject waitBeforeAttackPanel;

	void Awake () {
		waitBeforeAttackPanel = transform.GetChild(0).gameObject;
		waitText = waitBeforeAttackPanel.GetComponentInChildren<Text>();
		waitText.text = waitTime.ToString();

		fadeImg = waitBeforeAttackPanel.GetComponent<Image>();
		fadeTime = waitTime;
		waitBeforeAttackPanel.SetActive(false);
	}
	
	void Update () {
		fadeOut();
	}

	void fadeOut() {
		if(canFade) {
			Color temp = fadeImg.color;
			temp.a -=(Time.deltaTime / fadeTime) / 2;
			fadeImg.color = temp;
		}
	}

	public void activateFadeOut() {
		waitBeforeAttackPanel.SetActive(true);
		waitText.text = waitTime.ToString();
		Color temp = fadeImg.color;
		temp.a = 1;	
		fadeImg.color = temp;
		StartCoroutine(countDown());
	}

	IEnumerator countDown() {
		canFade = true;
		yield return new WaitForSeconds(1);
		waitTime -=1;

		if(waitTime != -1) {
			waitText.text = waitTime.ToString();
			StartCoroutine(countDown());
		} else if(waitTime == -1) {
			waitTime = fadeTime;
			waitBeforeAttackPanel.SetActive(false);
		}
	}
}
