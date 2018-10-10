using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMove : MonoBehaviour {

	public float ySpeed = 0;
	public float xSpeed = 0;
	public float zSpeed = 0;

	public bool local;

	void Update () {
		if(local) {
			transform.Translate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
		} else {
			transform.Translate(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime, Space.World);
		}
	}
}
