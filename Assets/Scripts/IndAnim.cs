using UnityEngine;
using System.Collections;
public class IndAnim : MonoBehaviour {
	public Sprite[] current;
	public int aniSpeed = 2;
	private int anicount = 0;
	private int aniStep = 0;
	void Start(){
		
	}

	public void clear(){
		
		gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		Debug.Log("call");
	}
	void FixedUpdate () {

		if ((anicount++) >= aniSpeed) {
			anicount = 0;
			aniStep++;
		}
		if (current.Length > 0) {
			if ((aniStep % current.Length) == 0)
				aniStep = 0;
			gameObject.GetComponent<SpriteRenderer> ().sprite = current [aniStep % current.Length];
		}
	}

}
