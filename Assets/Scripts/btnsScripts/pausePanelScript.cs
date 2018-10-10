using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pausePanelScript : MonoBehaviour {

	private GameObject pausePanel;
	private GameObject howToPlayPanel;
	private AudioSource audioSource;
	public Button musicBtn;
	public Sprite musicOff, musicOn;

	void Awake () {
		audioSource = GetComponent<AudioSource>();
		pausePanel = GameObject.Find("pause panel");
		pausePanel.SetActive(false);
		howToPlayPanel = GameObject.Find("HowToPlay");
		howToPlayPanel.SetActive(false);
		musicControll();
	}
	
	public void pauseGame() {
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void resumeGame() {
		pausePanel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void backToMain() {
		SceneManager.LoadScene("mainMenu");
	}

	public void musicControll() {
		if(GameManager.instace.musicOn) {
			musicBtn.image.sprite = musicOff;
			GameManager.instace.toggleMusic();
			audioSource.Play();
			}
		else {
			musicBtn.image.sprite = musicOn;
			GameManager.instace.toggleMusic();
			audioSource.Pause();
		}
	}	

	public void howToPlayPressed() {
		howToPlayPanel.SetActive(true);
	}
	public void closeHowToPlayPanle() {
		howToPlayPanel.SetActive(false);
	}	
}
