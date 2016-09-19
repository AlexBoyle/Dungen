using UnityEngine;
using System.Collections;
using XInputDotNetPure;
public class PlayerController : MonoBehaviour {
	public PlayerIndex controllerNum;
	public playerClass Class;
	private Ability script;
	public float playerSpeed = 1;
	private GamePadState state;
	private GamePadState prestate;
	private ImmortalObjectScript immortal;
	private int index;
	Quaternion currentRot;
	// Use this for initialization
	void Start () {
		immortal = GameObject.Find ("Immortal").GetComponent<ImmortalObjectScript> ();
		currentRot = Quaternion.identity;
		state = GamePad.GetState (controllerNum);
		prestate = state;
		switch(Class)
		{
		case playerClass.Rogue:
			index = 0;
			script = new Rogue ();
			break;
		case playerClass.Mage:
			index = 1;
			script = new Mage ();
			break;
		case playerClass.Tank:
			index = 2;
			script = new Tank ();
			break;
		case playerClass.Ranged:
			index = 3;
			script = new Ranged ();
			break;
		}
	}
	public void setPlayer(int controler, playerClass thisClass){
		currentRot = Quaternion.identity;
		controllerNum = (PlayerIndex)controler;
		prestate = state;
		Class = thisClass;
		switch(Class)
		{
		case playerClass.Rogue:
			index = 0;
			script = new Rogue ();
			break;
		case playerClass.Mage:
			index = 1;
			script = new Mage ();
			break;
		case playerClass.Tank:
			index = 2;
			script = new Tank ();
			break;
		case playerClass.Ranged:
			index = 3;
			script = new Ranged ();
			break;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		state = GamePad.GetState (controllerNum);
		gameObject.GetComponent<IndAnim> ().current = immortal.animations[index].getWalk();
		transform.position += new Vector3 (playerSpeed * state.ThumbSticks.Left.X, playerSpeed * state.ThumbSticks.Left.Y, 0);
		if (state.ThumbSticks.Left.X < 0)
			transform.rotation = Quaternion.Euler (180, 0, 180);
		else if (state.ThumbSticks.Left.X > 0)
			transform.rotation = Quaternion.Euler (0, 0, 0);
		else
			gameObject.GetComponent<IndAnim> ().current = immortal.animations[index].getIdle();
		script.abilityUpdate (state,prestate, gameObject);
		prestate = state;
	}

	Quaternion PointerRotation(GamePadThumbSticks.StickValue a){

		if ((Mathf.Abs (a.X) > .2f) || (Mathf.Abs (a.Y) > .2f)) {
			currentRot = Quaternion.Euler (0, 0, (Mathf.Atan2 (a.X, -a.Y) * Mathf.Rad2Deg) - 180);
			return currentRot;
		} else {
			return currentRot;
		}
	}
}
