using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {
	[SerializeField]
	private int levelLength;

	[SerializeField]
	private int startLevelLength = 5,endLevelLength = 5;

	[SerializeField]
	private int distanceBetweenPlatforms;

	[SerializeField]
	private Transform platformPrefab, platformParent;

	[SerializeField]
	private Transform monster, monsterParent;

	[SerializeField]
	private Transform collectable, collectableParent;

	[SerializeField]
	private float platformMinPosY = 0f,platformMaxPosY = 10f;

	[SerializeField]
	private int platformMinLength = 1,platformMaxLength = 4;

	[SerializeField]
	private float chanceForMonsterExistence=.25f, chanceForCollectableExistence=.1f;

	[SerializeField]
	private float collectableMinPosY = 1f,collectableMaxPosY = 3f;

	private float platformLastPosX;

	private enum platformType {
		None,
		Flat
	}

  	private class PlatformPositionInfo {
		public platformType type;
		public float positionY;
		public bool hasMonster;
		public bool hasCollectable;

		public PlatformPositionInfo(platformType Type, float posY, bool monster, bool collectable) {
			type = Type;
			positionY = posY;
			hasMonster = monster;
			hasCollectable = collectable;
		}

	}

	void Start(){
		generateLevel(true);
	}

	void fillPosInfo(PlatformPositionInfo[] platformInfo ) {
		int currentPlatformInfoIndex = 0;
		for(int i=0; i<startLevelLength;i++){
			platformInfo[currentPlatformInfoIndex].type = platformType.Flat;
			platformInfo[currentPlatformInfoIndex].positionY = 0f;

			currentPlatformInfoIndex++;
		}

		while (currentPlatformInfoIndex<(levelLength - endLevelLength)){
			if(platformInfo[currentPlatformInfoIndex-1].type != platformType.None){
				currentPlatformInfoIndex++;
				continue;
			}

			float platformPosY= Random.Range(platformMinPosY, platformMaxPosY);
			int platformLength = Random.Range(platformMinLength, platformMaxLength);

			for(int i=0;i<platformLength;i++){
				bool monster = (Random.Range(0f,1f) < chanceForMonsterExistence);
				bool collectable = (Random.Range(0f,1f) < chanceForCollectableExistence);

				platformInfo[currentPlatformInfoIndex].type = platformType.Flat;
				platformInfo[currentPlatformInfoIndex].positionY = platformPosY;
				platformInfo[currentPlatformInfoIndex].hasMonster = monster;
				platformInfo[currentPlatformInfoIndex].hasCollectable = collectable;

				currentPlatformInfoIndex++;

				if(currentPlatformInfoIndex > (levelLength - endLevelLength)){
					currentPlatformInfoIndex = levelLength - endLevelLength;
					break;
				}
			}
			for (int i=0; i < endLevelLength ; i++ ){
				platformInfo[currentPlatformInfoIndex].type = platformType.Flat;
				platformInfo[currentPlatformInfoIndex].positionY = 0f;

				currentPlatformInfoIndex++;
			}
		}
	}
	void creatPlatformFromPosInfo(PlatformPositionInfo [] platformPosInfo, bool gameStarted){
		for(int i=0;i<platformPosInfo.Length;i++){
			PlatformPositionInfo positionInfo = platformPosInfo[i];
			if(positionInfo.type == platformType.None)
				continue ; 
			Vector3 platformPosition;
			if(gameStarted){
				platformPosition = new Vector3 (distanceBetweenPlatforms*i, positionInfo.positionY , 0);
			}else {
				platformPosition = new Vector3 (distanceBetweenPlatforms + platformLastPosX, positionInfo.positionY , 0);
			}
			platformLastPosX = platformPosition.x;			
			Transform createBlock = (Transform)Instantiate(platformPrefab, platformPosition, Quaternion.identity);
			createBlock.parent = platformParent;
			
			if (positionInfo.hasMonster){
				if(gameStarted){
					platformPosition = new Vector3 (distanceBetweenPlatforms*i, positionInfo.positionY + 0.1f ,0);
				}else {
					platformPosition = new Vector3 (distanceBetweenPlatforms + platformLastPosX, positionInfo.positionY + 0.1f , 0);
				}
				Transform creatMonster = (Transform) Instantiate(monster, platformPosition, Quaternion.Euler(0,-90,0));
				creatMonster.parent = monsterParent;
			}			
			if (positionInfo.hasCollectable){
				if(gameStarted){
					platformPosition = new Vector3 (distanceBetweenPlatforms*i, positionInfo.positionY + Random.Range(collectableMinPosY, collectableMaxPosY) ,0);
				}else {
					platformPosition = new Vector3 (distanceBetweenPlatforms+platformLastPosX, positionInfo.positionY + Random.Range(collectableMinPosY, collectableMaxPosY) ,0);
				}
				Transform createHealth = (Transform) Instantiate(collectable, platformPosition, Quaternion.identity);
				createHealth.parent = collectableParent;

			}

		}

	}

	public void generateLevel(bool gameStarted){
		PlatformPositionInfo[] platformInfo=new PlatformPositionInfo[levelLength];

		for (int i=0;i<platformInfo.Length;i++){
			platformInfo[i] = new PlatformPositionInfo(platformType.None,-1f, false, false);
		}
		fillPosInfo(platformInfo);
		creatPlatformFromPosInfo(platformInfo, gameStarted);
	}

}
