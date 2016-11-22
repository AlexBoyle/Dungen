using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Rogue : Ability {
	private status playerState = status.Normal;
	private int stealthTimer = 0;
	private int AcoolDown = 0;
	private int XcoolDown = 0;
	private int BcoolDown = 0;
	private int YcoolDown = 0;
	private GameObject obj;
	private PlayerController con;
	public Rogue(GameObject obje){
		obj = obje;
		con = obj.GetComponent<PlayerController> ();
	}

	public override void abilityUpdate(GamePadState state,GamePadState prestate){
		//ability defs here

		//basic attack/crits in stealth
		if (state.Buttons.A == ButtonState.Pressed && prestate.Buttons.A == ButtonState.Released && AcoolDown < 0) {
			if (playerState == status.Normal) {
				damage = 10;
			} 
			else if (playerState == status.Stealth) {
				damage = 15;
			}
			con.basicAttack.SetActive (true);
			AcoolDown = 40;
		}

		//
		if (state.Buttons.B == ButtonState.Pressed && prestate.Buttons.B == ButtonState.Released && BcoolDown < 0) {
			if (playerState == status.Normal) {

			} 
			else if (playerState == status.Stealth) {

			}
		}

		//dash
		if (state.Buttons.X == ButtonState.Pressed && prestate.Buttons.X == ButtonState.Released && XcoolDown < 0) {
				playerState = status.Stealth;
				obj.transform.position +=  new Vector3 (state.ThumbSticks.Left.X * 6, state.ThumbSticks.Left.Y * 6, 0);
				stealthTimer = 60;
				XcoolDown = 120;
		}

		//stun/ranged stun
		if (state.Buttons.Y == ButtonState.Pressed && prestate.Buttons.Y == ButtonState.Released && YcoolDown < 0) {
			if (playerState == status.Normal) {

			} 
			else if (playerState == status.Stealth) {
				//
			}
		}
		if (playerState == status.Stealth) {
			obj.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, .2f);
			stealthTimer--;
		}
		else {
			obj.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
		}
		if (stealthTimer < 0) {
			playerState = status.Normal;
		}
		if (AcoolDown >= 0) {
			AcoolDown--;
		}
		if (BcoolDown >= 0) {
			BcoolDown--;
		}
		if (XcoolDown >= 0) {
			XcoolDown--;
		}
		if (YcoolDown >= 0) {
			YcoolDown--;
		}
	}
	

}
