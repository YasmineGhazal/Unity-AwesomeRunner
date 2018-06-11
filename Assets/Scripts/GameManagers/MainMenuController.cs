using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Button musicBtn;

	[SerializeField]
	private Sprite soundOn, soundOff; 
	public void PlayGame(){
		GameManager.instance.gamePlayedFromMainMenu = true;
		SceneManager.LoadScene(Tags.GAMEPLAY_SCENE);
	}

	public void controllMusic() {
		if(GameManager.instance.canPlayMusic) {
			musicBtn.image.sprite = soundOn;
			GameManager.instance.canPlayMusic = false;
		} else {
			musicBtn.image.sprite = soundOff;
			GameManager.instance.canPlayMusic = true;
		}
	}

}
