using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPerfabGenerator : MonoBehaviour {

	public GameObject[] skillPrefabs;
	private int  randNum;
	public int thisManyTimes = 3;
	public float overThisTime = 3f;
	public float xWidth, yWidth, zWidth;
	public bool allUseSameRotation;
	public float xRotarionMax, yRotarionMax = 180, zRotarionMax;
	private bool allRotationDecided;
	private float xCurrent, yCurrent, zCurrent;
	private float xRotarionCurrent, yRotarionCurrent, zRotarionCurrent;
	private float timeCounter;
	private float effectCounter;
	private float trigger;
	
	void Start () {
		if(thisManyTimes < 1) {
			thisManyTimes = 1;
		}
		trigger = overThisTime / thisManyTimes;
	}
	
	void Update () {
		timeCounter += Time.deltaTime;
		if(timeCounter > trigger && effectCounter <= thisManyTimes) {
			randNum = Random.Range(0,skillPrefabs.Length);
			xCurrent = transform.position.x + (Random.value * xWidth) - (xWidth * .5f);
			yCurrent = transform.position.y + (Random.value * yWidth) - (yWidth * .5f);
			zCurrent = transform.position.z + (Random.value * zWidth) - (zWidth * .5f);

			if(!allUseSameRotation || !allRotationDecided) {
				xRotarionCurrent = transform.rotation.x + (Random.value * xRotarionMax * 2) - xRotarionMax;
				yRotarionCurrent = transform.rotation.y + (Random.value * yRotarionMax * 2) - yRotarionMax;
				zRotarionCurrent = transform.rotation.z + (Random.value * zRotarionMax * 2) - zRotarionMax;
				allRotationDecided = true;				
			}

			GameObject skill = Instantiate (skillPrefabs[randNum], new Vector3(xCurrent, yCurrent, zCurrent), transform.rotation);
			skill.transform.Rotate(xRotarionCurrent, yRotarionCurrent, zRotarionCurrent);

			timeCounter -= trigger;
			effectCounter +=1;
			
		}
	}
}
