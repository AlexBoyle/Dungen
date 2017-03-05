using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Ranged : Ability {
	private int AcoolDown = 0;
	private int XcoolDown = 0;
	private int BcoolDown = 0;
	private int YcoolDown = 0;
	private int inv_time = 0;
	public bool inv = false;
	private bool right = true;
	private bool left = false;
	private GameObject obj;
	private PlayerController con;
	public Ranged(GameObject obje){
		obj = obje;
		con = obj.GetComponent<PlayerController> ();
	}

	public override bool abilityYUpdate(GamePadState state,GamePadState prestate){
		if (state.Buttons.Y == ButtonState.Pressed && prestate.Buttons.Y == ButtonState.Released && YcoolDown < 0) {
			for (float i = .5f; i <= 4; i+= .5f) {
				makeArrow (state, i);
			}
			YcoolDown = 120;

			return true;
		}
		return false;
	}
	public override bool abilityAUpdate(GamePadState state,GamePadState prestate){
		return false;
	}
	public override bool abilityBUpdate(GamePadState state,GamePadState prestate){
		if (state.Buttons.B == ButtonState.Pressed && prestate.Buttons.B == ButtonState.Released && BcoolDown < 0) {
			makeArrow (state, 1.5f, effect.Root);
			BcoolDown = 180;
			return true;
		}
		return false;
	}
	public override bool abilityXUpdate(GamePadState state,GamePadState prestate){
		if (state.Buttons.X == ButtonState.Pressed && prestate.Buttons.X == ButtonState.Released) {
			makeArrow (state, 1.5f);
			return true;
		}
		return false;
	}
	public override void abilityUpdate(GamePadState state,GamePadState prestate){
		if (state.ThumbSticks.Left.X > .2f || state.ThumbSticks.Left.X < -.2f) {
			right = state.ThumbSticks.Left.X > .2f;
			left = state.ThumbSticks.Left.X < -.2f;
		}
		if (AcoolDown >= 0) {
			AcoolDown--;
		}
		if (BcoolDown >= 0) {
			BcoolDown--;
		}
		if (XcoolDown >= 0) {
			XcoolDown--;
		} else if(XcoolDown == -1){
			XcoolDown--;
		}
		if (YcoolDown >= 0) {
			YcoolDown--;
		}
		if (inv_time >= 0) {
			inv_time--;
		}
	}
	private void makeArrow(GamePadState state,float  degree, effect e = effect.Null){
		GameObject arrow = GameObject.Find("ArrowPool").GetComponent<pool>().FetchObject();
		arrow.transform.position = obj.transform.position;
		arrow.SetActive (true);
		arrow.GetComponent<dmg> ().eff = new Effect(e,60);
		if(e == effect.Root)
			arrow.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 1, 1);
		if (right) {
			arrow.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (800, degree * 200));
		} else if (left) {
			arrow.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-800, degree * 200));
			arrow.transform.position = obj.transform.position - new Vector3 (.5f, 0, 0);
		}
	}


}
