using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour {
	public GameObject attack;
	public int cool = 60;
	public int moveTime = 5 * 60;
	public int dir = 1;
	public int anilock = -1;
	private Vector3 cur = new Vector3();
	private Vector3 pre = new Vector3();
	private animationState an;
	private ImmortalObjectScript immortal;
	// Update is called once per frame
	void Start () {
		immortal = GameObject.Find ("Immortal").GetComponent<ImmortalObjectScript> ();
		attack.SetActive (false);
	}
	void FixedUpdate () {
		if (anilock >=0)
			anilock--;
		cur = gameObject.transform.position;
		an = animationState.still;

		if (cur.x - pre.x > 0) {
			transform.rotation = Quaternion.Euler (180, 0, 180);
			an = animationState.walk;
		} else if (cur.x - pre.x < 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			an = animationState.walk;
		}
		if (cool < 0 && moveTime > 0) {
			cool = (int)((Random.value * 100)/2) + 60;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (((Random.value/2)+ .5f) * 14 * dir, 0);
			dir *= -1;
		}
		else
			cool --;
		moveTime--;
		if (moveTime == 0) {
			
			an = animationState.x;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}
		if (moveTime < -2 * 60)
			moveTime = 6 * 60;
		if(anilock <0)
		switch (an) {
		case animationState.still:
			attack.SetActive (false);
			gameObject.GetComponent<IndAnim> ().current = immortal.animations [4].getIdle ();
			break;
		case animationState.walk:
			attack.SetActive (false);
			gameObject.GetComponent<IndAnim> ().current = immortal.animations [4].getWalk ();
			break;
		case animationState.x:
			gameObject.GetComponent<IndAnim> ().current = immortal.animations [4].getAbilityX ();
			attack.SetActive (true);
			anilock = immortal.animations [4].getAbilityX().Length * gameObject.GetComponent<IndAnim> ().aniSpeed; 
			break;
		}
		pre = cur;
	}
}
