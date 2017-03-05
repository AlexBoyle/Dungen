using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (GameObject.Find ("BossContainer").transform.GetChild (0).GetComponent<BoxCollider2D> (), GetComponent<BoxCollider2D> ());
	}
}
