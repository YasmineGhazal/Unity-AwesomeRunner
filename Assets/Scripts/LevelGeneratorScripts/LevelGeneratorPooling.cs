using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorPooling : MonoBehaviour {

	[SerializeField]
	private Transform platform, platformParent;
	[SerializeField]
	private Transform monster, monsterParent;
	[SerializeField]
	private Transform health, healthParent;
	[SerializeField]
	private int levelLength = 100;
	[SerializeField]
	private float destanceBetweenPlatforms = 15f;
	[SerializeField]
	private float minPosY = 0f, maxPosY = 7f;
	[SerializeField]
	private float monsterExistance = .25f, healthExistance= 0.1f;
	[SerializeField]
	private float healthMinY = 0f, healthMaxY = 3f;
	private float platformLastPosX;
	private Transform[] platformArray;

	void Start () {
		creatPlatforms();
	}
	void creatPlatforms(){
		platformArray = new Transform[levelLength];

		for(int i=0; i<levelLength; i++){
			Transform newPlatform = (Transform) Instantiate(platform, Vector3.zero, Quaternion.identity);
			platformArray[i] = newPlatform;
			float platformPosY = Random.Range(minPosY, maxPosY);
			Vector3 platformPos;
			if(i<2)
				platformPosY = 0f;
			platformPos = new Vector3(destanceBetweenPlatforms * i, platformPosY, 0);
			platformLastPosX = platformPos.x;
			platformArray[i].position = platformPos;
			platformArray[i].parent = platformParent;
			spawnHealthAndMonsters(platformPos, i, true);

		}
	}

	public void PoolingPlatforms(){
		for(int i=0; i<levelLength; i++){
			if(!platformArray[i].gameObject.activeInHierarchy){
				platformArray[i].gameObject.SetActive(true);
				float platformPosY = Random.Range(minPosY, maxPosY);
				Vector3 platformPos = new Vector3(destanceBetweenPlatforms + platformLastPosX, platformPosY, 0f);
				platformArray[i].position = platformPos;
				platformLastPosX = platformPos.x;
				spawnHealthAndMonsters(platformPos, i, false);
			}
		}
	}

	void spawnHealthAndMonsters(Vector3 platformPos, int i, bool gameStarted){
		if(i>2){
			if(Random.Range(0f,1f) < monsterExistance){
				if(gameStarted){
					platformPos = new Vector3(destanceBetweenPlatforms * i, platformPos.y + 0.1f, 0);
				}else {
					platformPos = new Vector3(destanceBetweenPlatforms + platformLastPosX, platformPos.y + 0.1f, 0);
				}

				Transform createMonster = (Transform) Instantiate(monster, platformPos, Quaternion.Euler(0,-90,0));
				createMonster.parent = monsterParent;
			}

			if(Random.Range(0f,1f) < healthExistance){
				if(gameStarted){
					platformPos = new Vector3(destanceBetweenPlatforms * i, platformPos.y + Random.Range(healthMinY,healthMaxY), 0);
				}else {
					platformPos = new Vector3(destanceBetweenPlatforms + platformLastPosX, platformPos.y + Random.Range(healthMinY,healthMaxY), 0);
				}

				Transform createHealth = (Transform) Instantiate(health, platformPos, Quaternion.identity);
				createHealth.parent = healthParent;
			}

		}
	}
}

