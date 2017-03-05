using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour {

	public GameObject monst;
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.GetComponent<UnityEngine.UI.Slider>().value =  (float)monst.GetComponent<Monst> ().health / (float)monst.GetComponent<Monst> ().maxHealth;
	}
}
