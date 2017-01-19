using UnityEngine;
using System.Collections;

public class SlimeProj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 ((Random.value * 1000) - 500, (Random.value * 1000) - 500));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
