using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Tank : Ability {


	public override bool abilityYUpdate(GamePadState state,GamePadState prestate){return false;}
	public override bool abilityAUpdate(GamePadState state,GamePadState prestate){return false;}
	public override bool abilityBUpdate(GamePadState state,GamePadState prestate){return false;}
	public override bool abilityXUpdate(GamePadState state,GamePadState prestate){return false;}
	public override void abilityUpdate(GamePadState state,GamePadState prestate){
		//ability defs here
		if (state.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released) {

		}
		if (state.Buttons.B == ButtonState.Pressed && state.Buttons.B == ButtonState.Released) {

		}
		if (state.Buttons.X == ButtonState.Pressed && state.Buttons.X == ButtonState.Released) {

		}
		if (state.Buttons.Y == ButtonState.Pressed && state.Buttons.Y == ButtonState.Released) {

		}
	}


}
