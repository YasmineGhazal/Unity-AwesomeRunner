using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttackBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private PlayerAttacks playerAttacks;
	
	void Awake () {
		playerAttacks = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttacks>();
	}

	public void OnPointerDown(PointerEventData data) {
		playerAttacks.attackBtnPressed();
	} 

	public void OnPointerUp(PointerEventData data) {
		playerAttacks.attackBtnReleased();
	} 
	
}
