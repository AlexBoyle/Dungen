using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour {

	public Sprite[] move;
	public Sprite[] attack;
	public int cool = 60;
	public int moveTime = 5 * 60;
	public int dir = 1;
	// Update is called once per frame
	void Update () {
		if (cool < 0 && moveTime > 0) {
			cool = (int)((Random.value * 100)/2) + 60;
			Debug.Log (cool);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (((Random.value/2)+ .5f) * 14 * dir, 0);
			dir *= -1;
		}
		else
			cool --;
		moveTime--;
		if(moveTime == 0)
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		if (moveTime < -5 * 60)
			moveTime = 5 * 60;
	}
}
