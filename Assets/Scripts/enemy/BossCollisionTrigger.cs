using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollisionTrigger : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D Coll)
	{
		if (Coll.gameObject.tag == "Player")
			gameObject.GetComponentInParent<HitBoxManagerB3>().WalkForward();
	}
}
