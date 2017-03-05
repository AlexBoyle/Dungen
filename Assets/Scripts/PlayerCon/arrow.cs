using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag != "Player") {
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			gameObject.SetActive (false);
			GetComponent<dmg> ().eff = new Effect (effect.Null, 0);
		}
	}
	void FixedUpdate () {
		Vector2 dir = gameObject.GetComponent<Rigidbody2D> ().velocity;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
