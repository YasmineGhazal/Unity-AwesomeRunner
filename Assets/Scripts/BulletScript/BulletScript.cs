using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float bulletLifeTime = 5f;
	public float startY;

	void Start () {
		startY = transform.position.y;
	}

	void LateUpdate () {
		transform.position = new Vector3(transform.position.x, startY, transform.position.z);
	}

	IEnumerator TurnOffBullet() {
		yield return new WaitForSeconds(bulletLifeTime);
		gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider target) {
		if(target.tag == Tags.MONSTER ||target.tag == Tags.PLAYER_TAG ||target.tag == Tags.MONSTER_BULLET ||target.tag == Tags.PLAYER_BULLET)
			gameObject.SetActive(false);			
	}
}
