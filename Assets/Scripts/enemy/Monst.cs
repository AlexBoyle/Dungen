using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monst : MonoBehaviour{

	public int health = 100;
	public List<Effect> effects = new List<Effect>(); 

	void Start () {
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player")
		health -= col.transform.parent.parent.GetComponent<PlayerController> ().script.damage;
	}
	public void doDamage(int a){
		health -= a;
	}
	public void addEffect (Effect a){
		effects.Add (a);
	}

	void FixedUpdate () {
		int len = effects.Count;
		for(int i = 0; i < len; i ++){
			if (effects[i].time > 0) {
				effects[i].time -= 1;
				Debug.Log (effects[i].time);
			}
		}
	}

}

