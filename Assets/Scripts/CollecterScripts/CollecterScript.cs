using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecterScript : MonoBehaviour {
	void OnTriggerEnter(Collider target) {
		if(target.tag == Tags.HEALTH || target.tag == Tags.MONSTER || target.tag == Tags.PLATFORM_TAG)
			target.gameObject.SetActive(false);	
	}
}
