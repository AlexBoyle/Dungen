using UnityEngine;
using System.Collections;
using XInputDotNetPure;
public class PlayerController : MonoBehaviour {
	public PlayerIndex controllerNum;
	public playerClass Class;
	public GameObject attackDir;
	public GameObject basicAttack;
	public Ability script;
	public float playerSpeed = 1;
	public bool falling = false;
	private GamePadState state;
	private GamePadState prestate;
	private ImmortalObjectScript immortal;
	private int index;
	private animationState a;
	private Vector3 prePos = new Vector3 ();
	public int anilock = -1;
	Quaternion currentRot;
	Rigidbody2D RB;
	// Use this for initialization
	void Start () {
		immortal = GameObject.Find ("Immortal").GetComponent<ImmortalObjectScript> ();
		basicAttack.SetActive (false);
		RB = GetComponent<Rigidbody2D> ();
		currentRot = Quaternion.identity;
		state = GamePad.GetState (controllerNum);
		prestate = state;
		switch(Class)
		{
		case playerClass.Rogue:
			index = 0;
			script = new Rogue (gameObject);
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
			script = new Rogue (gameObject);
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
		if(anilock > -1)
			anilock --;
		if (anilock < 0) {
			basicAttack.SetActive (false);
			a = animationState.still;
		}
		state = GamePad.GetState (controllerNum);
		if(Mathf.Abs(prePos.y - transform.position.y) > 0.001f){falling = true;} else{ falling=false;}
		gameObject.GetComponent<IndAnim> ().current = immortal.animations[index].getWalk();
		RaycastHit2D groundCheck = Physics2D.Raycast (transform.position, Vector2.down, .35f);
		RB.velocity = new Vector2 (playerSpeed * state.ThumbSticks.Left.X, RB.velocity.y);
		if (state.Buttons.A == ButtonState.Pressed && prestate.Buttons.A == ButtonState.Released && !falling) {
			RB.velocity += new Vector2 (0, 16);
		}
		if (state.ThumbSticks.Left.X < 0) {
			transform.rotation = Quaternion.Euler (180, 0, 180);
			if(anilock < 0)
				a = animationState.walk;
		} else if (state.ThumbSticks.Left.X > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			if(anilock < 0)
				a = animationState.walk;
		}
		if (falling && anilock < 0)
			a = animationState.falling;
		if (script.abilityAUpdate (state, prestate))
			a = animationState.a;
		if (script.abilityBUpdate (state, prestate))
			a = animationState.b;
		if (script.abilityXUpdate (state, prestate))
				a = animationState.x;
		if (script.abilityYUpdate (state, prestate))
				a = animationState.y;
		script.abilityUpdate (state,prestate);
		switch (a) {
		case animationState.spin:
			gameObject.GetComponent<IndAnim> ().current = immortal.animations[index].getSpin();
			break;
		case animationState.still:
			gameObject.GetComponent<IndAnim> ().current = immortal.animations[index].getIdle();
			break;
		case animationState.walk:
			gameObject.GetComponent<IndAnim> ().current = immortal.animations[index].getWalk();
			break;
		case animationState.a:
			gameObject.GetComponent<IndAnim> ().current = immortal.animations [index].getAbilityA ();
			if (anilock < 0) {
				anilock = immortal.animations [index].getAbilityA ().Length * gameObject.GetComponent<IndAnim> ().aniSpeed;
				gameObject.GetComponent<IndAnim> ().frame = 0;
			}
			break;
		case animationState.b:
			gameObject.GetComponent<IndAnim> ().current = immortal.animations [index].getAbilityB ();
			if (anilock < 0) {
				anilock = immortal.animations [index].getAbilityB ().Length * gameObject.GetComponent<IndAnim> ().aniSpeed;
				gameObject.GetComponent<IndAnim> ().frame = 0;
			}
			break;
		case animationState.x:
			basicAttack.SetActive (true);
			gameObject.GetComponent<IndAnim> ().current = immortal.animations [index].getAbilityX ();
			if (anilock < 0) {
				anilock = immortal.animations [index].getAbilityX ().Length * gameObject.GetComponent<IndAnim> ().aniSpeed;
				gameObject.GetComponent<IndAnim> ().frame = 0;
			}
			break;
		case animationState.y:
			gameObject.GetComponent<IndAnim> ().current = immortal.animations [index].getAbilityY ();
			if (anilock < 0) {
				anilock = immortal.animations [index].getAbilityY ().Length * gameObject.GetComponent<IndAnim> ().aniSpeed;
				gameObject.GetComponent<IndAnim> ().frame = 0;
			}
			break;
		}
		prestate = state;
		prePos = transform.position;
		attackDir.transform.rotation =  PointerRotation (state.ThumbSticks.Left);
	}

	Quaternion PointerRotation(GamePadThumbSticks.StickValue a){

		if ((Mathf.Abs (a.X) > .2f) || (Mathf.Abs (a.Y) > .2f)) {
			float temp = (Mathf.Atan2 (a.X, -a.Y) * Mathf.Rad2Deg) - 90;
			//Debug.Log (temp);
			currentRot = Quaternion.Euler (0, 0, temp);
			return currentRot;
		} else {
			return currentRot;
		}
	}
}
