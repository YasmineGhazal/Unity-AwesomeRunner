using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDamageShoot : MonoBehaviour {

	public static bool canShoot;

	private Button shootBtn;

	[SerializeField]
	private Transform playerBullet;
	private float distanceBeforeNewPlatform = 150f;
	private LevelScript levelGenerator;
	private LevelGeneratorPooling levelGeneratorPooling;

	void Awake () {
		levelGenerator = GameObject.Find(Tags.LEVEL_GENERATOR).GetComponent<LevelScript>();
		levelGeneratorPooling = GameObject.Find(Tags.LEVEL_GENERATOR).GetComponent<LevelGeneratorPooling>();
		shootBtn = GameObject.Find(Tags.SHOOT_BTN).GetComponent<Button>();
		shootBtn.onClick.AddListener( () => Fire());
		
   	}

	void OnTriggerEnter(Collider target) {
		if(target.tag == Tags.MONSTER_BULLET || target.tag == Tags.BOUNDS){
			playerDied();
			}
		if(target.tag == Tags.HEALTH){
			gamePlayController.instance.incrementHealth();
			target.gameObject.SetActive(false);
		}	
		if(target.tag == Tags.MORE_PLATFOMS){
			Vector3 temp = target.transform.position;
			temp.x += distanceBeforeNewPlatform;
			target.transform.position = temp; 
			//levelGenerator.generateLevel(false);
			levelGeneratorPooling.PoolingPlatforms();
		}
	}

	void OnCollisionEnter(Collision target){
		if(target.transform.tag == Tags.MONSTER){
			playerDied();
		}
	}

	void Fire(){
			if(canShoot){
			Vector3 temp = transform.position;
			temp.y += 1.5f;
			temp.x += 1f;
			Transform newBullet = (Transform) Instantiate(playerBullet, temp, Quaternion.identity);
			newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1500f);
			newBullet.parent = transform;}		
	}

	void playerDied(){
		gamePlayController.instance.takeDamage();
		Destroy(gameObject);
		Monster.canShoot = false;
	}
}
