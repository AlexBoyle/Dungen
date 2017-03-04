using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManagerB3 : MonoBehaviour {
	public GameObject attack1;
	int attack1NumChildren =3;
	public GameObject set1;
	public GameObject set2;
	public GameObject set3;
	public GameObject blocklow;
	public GameObject blockhigh;
	public GameObject walkForawardTrig;
	public float speedMax = 0;
	float currentSpeed;
	bool inAState = false;
//	public GameObject[] attack1HitBoxes;
//attack1HitBoxes = attack1.GetComponentsInChildren<GameObject>();
	//public Transform[]attack1Children;
	public GameObject[] attack1ChildrenObjects; //Hit Boxes for attack1
	int value =0;
	void Start(){
		//Attack1();
		//WalkForward();
		//BlockHigh();
		//TurnAround();
	}

	// Update is called once per frame
	void FixedUpdate () {
		
	}
	// ATTACKS ******************************************
	public void Attack1(){
		if (!inAState) {
			StartCoroutine (Attack1Enumer ());
		}
	}
	IEnumerator Attack1Enumer(){
		inAState = true;
		set1.SetActive(true); //I think the index 0 holds the parent
		yield return new WaitForSeconds (.2f);
		set1.SetActive (false);
		set2.SetActive(true); //I think the index 0 holds the parent
		yield return new WaitForSeconds (.2f);
		set2.SetActive (false);
		set3.SetActive(true); //I think the index 0 holds the parent
		yield return new WaitForSeconds (1.5f);
		set3.SetActive (false);
		inAState = false;
	}


	// OTHER ACTIONS *****************************************
	public void WalkForward()
	{
		if (!inAState) {
			StartCoroutine (WalkEnumer());		
		}
	}
	IEnumerator WalkEnumer()
	{
		inAState = true;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speedMax, 0);
		yield return new WaitForSeconds (.2f);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		inAState = false;
	}
	public void TurnAround()
	{
		if (!inAState) {
			StartCoroutine (TurnAroundEnumer());
		}
	}
	IEnumerator TurnAroundEnumer()
	{
		inAState = true;
		if (transform.rotation != Quaternion.Euler (180, 0, 180)) {
			transform.rotation = Quaternion.Euler (180, 0, 180);
			yield return new WaitForSeconds (.2f);
		}
		else { 
			transform.rotation = Quaternion.Euler (0, 0, 0);
			yield return new WaitForSeconds (.2f);
		}
		inAState = false;
	}

	public void BlockLow()
	{
		if (!inAState) {
			StartCoroutine (BlockLowEnum());
		}
	}
	IEnumerator BlockLowEnum()
	{
		inAState = true;
		blocklow.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		blocklow.SetActive (false);
		inAState = false;
	}
	public void BlockHigh()
	{
		if (!inAState) {
			StartCoroutine (BlockHighEnum());
		}
	}
	IEnumerator BlockHighEnum()
	{
		inAState = true;
		blockhigh.SetActive (true);
		yield return new WaitForSeconds (1.5f);
		blockhigh.SetActive (false);
		inAState = false;
	}
}
