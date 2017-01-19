using UnityEngine;
using System.Collections;
public class IndAnim : MonoBehaviour {
	public Sprite[] current;
	public bool loop = true;
	public int aniSpeed = 2;
	private int anicount = 0;
	public int frame = 0;
	public bool resetOnEnable = true;
	void OnEnable() {
		if (resetOnEnable) {
			frame = 0;
			anicount = 0;
			if (current.Length > 0)
				gameObject.GetComponent<SpriteRenderer> ().sprite = current [0];
		}
	}
	public void clear(){

		gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		Debug.Log("call");
	}
	void FixedUpdate () {

		if ((anicount++) >= aniSpeed) {
			anicount = 0;
			frame++;
			if (!loop && frame == current.Length)
				gameObject.SetActive (false);
		}
		if (current.Length > 0) {
			if ((frame % current.Length) == 0 && loop) {
				frame = 0;
			}
			if(!(frame > current.Length - 1))
				gameObject.GetComponent<SpriteRenderer> ().sprite = current [frame % current.Length];
		}
	}

}
