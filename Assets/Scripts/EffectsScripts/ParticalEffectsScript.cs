using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalEffectsScript : MonoBehaviour {

	public float timer = 1f;
	void Start () {
		StartCoroutine(stopEffect());
	}
	
	IEnumerator stopEffect(){
		yield return new WaitForSeconds(timer);
		gameObject.SetActive(false);
	}
}
