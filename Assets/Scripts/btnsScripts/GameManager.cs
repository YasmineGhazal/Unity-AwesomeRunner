using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instace;

	[HideInInspector]
	public bool musicOn = true;
	void Awake () {
		MakeSingleton();
	}
	
	void MakeSingleton() {
		if(instace != null)
			Destroy(gameObject);
		else {
			instace = this;
			DontDestroyOnLoad(gameObject);				
		}
	}

	public void toggleMusic() {
		musicOn = !musicOn;
	}
}
