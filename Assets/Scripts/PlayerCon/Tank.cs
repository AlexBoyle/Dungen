using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Tank : Ability {
	private int AcoolDown = 0;
	private int XcoolDown = 0;
	private int BcoolDown = 0;
	private int YcoolDown = 0;
	private int inv_time = 0;
	public bool inv = false;
	private GameObject obj;
	private PlayerController con;
	public Tank(GameObject obje){
		obj = obje;
		con = obj.GetComponent<PlayerController> ();
	}
	public override bool abilityYUpdate(GamePadState state,GamePadState prestate){
		if (state.Buttons.Y == ButtonState.Pressed && prestate.Buttons.Y == ButtonState.Released && YcoolDown < 0) {
			inv = true;
			obj.GetComponent<SpriteRenderer> ().color = new Color (.4f, .4f, .4f, 1);
			inv_time = 60;
			YcoolDown = 180;
			return true;
		}
		return false;
	}
	public override bool abilityAUpdate(GamePadState state,GamePadState prestate){
		return false;
	}
	public override bool abilityBUpdate(GamePadState state,GamePadState prestate){
		if (state.Buttons.B == ButtonState.Pressed && prestate.Buttons.B == ButtonState.Released && BcoolDown < 0) {
			obj.transform.position += new Vector3 (state.ThumbSticks.Left.X * 6, state.ThumbSticks.Left.Y * 6, 0);
			BcoolDown = 120;
			return true;
		}
		return false;
	}
	public override bool abilityXUpdate(GamePadState state,GamePadState prestate){
		if (state.Buttons.X == ButtonState.Pressed && prestate.Buttons.X == ButtonState.Released && XcoolDown < 0) {
			damage = 10;
			XcoolDown = 20;
			return true;
		}
		return false;
	}
	public override void abilityUpdate(GamePadState state,GamePadState prestate){
		if (inv_time < 0) {
			obj.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			inv = false;
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


}