using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Monst : MonoBehaviour{
	private animationState an;
	public int maxHealth = 100;
	public int health = 100;
	public List<Effect> effects = new List<Effect>(); 
	private ImmortalObjectScript immortal;
	void Start () {
		immortal = GameObject.Find ("Immortal").GetComponent<ImmortalObjectScript> ();
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			health -= col.GetComponent<dmg> ().damage;
			effects.Add (col.GetComponent<dmg> ().eff);
		}
	}
	public void doDamage(int a){
		health -= a;
	}
	public void addEffect (Effect a){
		effects.Add (a);
	}

	void FixedUpdate () {
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		int len = effects.Count;
		for(int i = 0; i < len; i ++){
			if (effects[i].time > 0) {
				effects[i].time -= 1;
				switch (effects [i].effect) {
				case effect.Root:
					GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1, 1);
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
					break;
				}
			}
			else
				effects.RemoveAt (i);
		}
	}

}

