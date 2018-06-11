using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {

	private float collectionSoundEffect = 1f;
	public float audioFootVolume = 1f;
	public float soundEffectPitchRandomness = 0.05f;

	private AudioSource audioSource;
	public AudioClip genericFootSound;
	public AudioClip metalFootSound;
	void Awake () {
		audioSource = GetComponent<AudioSource> ();
	}

	void footSound(){
		audioSource.volume = collectionSoundEffect * audioFootVolume ;
		audioSource.pitch = Random.Range(1-soundEffectPitchRandomness, 1+soundEffectPitchRandomness);

		if(Random.Range(0, 2)> 0){
			audioSource.clip = genericFootSound;
		}else {
			audioSource.clip = metalFootSound;
		}

		audioSource.Play();
	}
	
}
