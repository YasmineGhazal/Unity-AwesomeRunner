using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuBtns : MonoBehaviour {

	[SerializeField]
	private Sprite musicOn, musicOff;
	private GameObject howToPlayPanel;
	public Button musicBtn;
	private GameObject loadingScreen;
	private Slider loadingSlider;
	private Text loadingText;

	void Awake() {
		Time.timeScale = 1f;
		howToPlayPanel = GameObject.Find("howToPlay");
		howToPlayPanel.SetActive(false);
		loadingScreen = GameObject.Find("loadingScreen");
		loadingSlider = loadingScreen.GetComponentInChildren<Slider>();
		loadingText = loadingScreen.GetComponentInChildren<Text>();
		loadingScreen.SetActive(false);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	void Start() {
		musicControll();
	}

	public void playGame() {
		StartCoroutine(loadLevel());
	}
	
	IEnumerator loadLevel() {
		AsyncOperation AO= SceneManager.LoadSceneAsync("GamePlay");
		loadingScreen.SetActive(true);
		while(!AO.isDone) {
			float progress = Mathf.Clamp01(AO.progress/.95f);
			loadingSlider.value = progress;
			loadingText.text = Mathf.Ceil(progress*100) +" %";
			yield return null;
		}

	}

	public void musicControll() {
		if(GameManager.instace.musicOn) {
			musicBtn.image.sprite = musicOn;
			GameManager.instace.toggleMusic();
			}
		else {
			musicBtn.image.sprite = musicOff;
			GameManager.instace.toggleMusic();
		}
	}	

	public void howToPlayPressed() {
		howToPlayPanel.SetActive(true);
	}
	public void closeHowToPlayPanle() {
		howToPlayPanel.SetActive(false);
	}	

}
