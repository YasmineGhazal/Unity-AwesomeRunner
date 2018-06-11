using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamePlayController : MonoBehaviour {

	public static gamePlayController instance;
	private Text healthTxt, scoreTxt, levelTxt;
	private float health, score, level;
	[HideInInspector]
	public bool canIncrementScore;

	private BGScroller bgScroller;
	private GameObject pausePanel;

	[SerializeField]	
	private AudioSource audioSource;
	void Awake () {
		makeInstace();
		scoreTxt = GameObject.Find(Tags.SCORE_TEXT).GetComponent<Text>();
		levelTxt = GameObject.Find(Tags.LEVEL_TEXT).GetComponent<Text>();
		healthTxt = GameObject.Find(Tags.HEALTH_TEXT).GetComponent<Text>();
		bgScroller = GameObject.Find(Tags.BG).GetComponent<BGScroller>();
		pausePanel = GameObject.Find(Tags.PAUSE_PANEL);
		pausePanel.SetActive(false);
	}

	void Start() {
        StartCoroutine("incrementEverySec");
		if(GameManager.instance.canPlayMusic)
			audioSource.Play();
    }

	IEnumerator incrementEverySec() {
		for(;;) {
			incrementScore(1);
			yield return new WaitForSeconds(1f);
		}
	}
	void OnEnable() {
		SceneManager.sceneLoaded += onSceneLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= onSceneLoaded;
		instance = null;
	}

	void makeInstace(){
		if(instance == null)
			instance = this;
	}

	void onSceneLoaded(Scene scene, LoadSceneMode mode){
		if(scene.name == Tags.GAMEPLAY_SCENE){
			if(GameManager.instance.gamePlayedFromMainMenu){
				GameManager.instance.gamePlayedFromMainMenu = false;
				score = 0;
				health = 2;
				level = 0;
			} else if (GameManager.instance.gameRestartedPlayerDied){
				GameManager.instance.gameRestartedPlayerDied = false;
				score = GameManager.instance.score;
				health = GameManager.instance.health;
			}
			scoreTxt.text = score + "";
			healthTxt.text = health + "";
			levelTxt.text = level + "";
		}
		
	}

	public void incrementScore(float scoreValue){
		if(canIncrementScore){
			score += scoreValue;
			scoreTxt.text = score + "";
		}
	}

	public void incrementHealth() {
		health++ ;
		healthTxt.text = health + "" ;
	}

	public void takeDamage() {
		health--;
		if(health >= 0){
			StartCoroutine(playerDied(Tags.GAMEPLAY_SCENE));
			healthTxt.text = health + "";
		} else {
			StartCoroutine(playerDied(Tags.MAINMENU_SCENE));
		}
	}

	IEnumerator playerDied(string sceneName){ 
		
		canIncrementScore = false;
		bgScroller.canScroll = false;
		GameManager.instance.health = health;
		GameManager.instance.score = score;
		GameManager.instance.gameRestartedPlayerDied = true;

		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadScene(sceneName);

	}

	public void pauseGame() {
		canIncrementScore = false;
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
		bgScroller.canScroll = false;
	}

	public void resumeGame() {
		canIncrementScore = true;
		pausePanel.SetActive(false);
		Time.timeScale = 1f;
		}

	public void backToMain() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(Tags.MAINMENU_SCENE);
	}	

	public void replay() {
		Time.timeScale = 1f;
		GameManager.instance.gamePlayedFromMainMenu = true;
		SceneManager.LoadScene(Tags.GAMEPLAY_SCENE);
	}
}
