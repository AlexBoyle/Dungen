using UnityEngine;
using System.Collections;
public class IndAnim : MonoBehaviour {
	public Sprite[] current;
	public bool loop = true;
	public int aniSpeed = 2;
	private int anicount = 0;
	private int aniStep = 0;
	void Start(){
		
	}
	void OnEnable() {
		aniStep = 0;
		anicount = 0;
		if(current.Length > 0)
			gameObject.GetComponent<SpriteRenderer> ().sprite = current [0];
	}
	public void clear(){
		
		gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		Debug.Log("call");
	}
	void FixedUpdate () {

		if ((anicount++) >= aniSpeed) {
			anicount = 0;
			aniStep++;
			if (!loop && aniStep == current.Length)
				gameObject.SetActive (false);
		}
		if (current.Length > 0) {
			if ((aniStep % current.Length) == 0 && loop)
				aniStep = 0;
			if(!(aniStep > current.Length - 1))
				gameObject.GetComponent<SpriteRenderer> ().sprite = current [aniStep % current.Length];
		}
	}

}
