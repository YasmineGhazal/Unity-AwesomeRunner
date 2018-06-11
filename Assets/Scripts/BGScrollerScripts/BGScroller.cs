using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	public float offsetSpeed = -0.0006f;
	[HideInInspector]
	public bool canScroll ;
	private Renderer myRenderer;
	void Awake() {
		myRenderer = GetComponent<MeshRenderer> ();
	}
	void Update () {
		if (canScroll)
			myRenderer.material.mainTextureOffset -= new Vector2 (offsetSpeed, 0);
	}
}
