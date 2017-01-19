using UnityEngine;
using System.Collections;
using XInputDotNetPure;
public abstract class Ability {
	public int damage = 0;
	public abstract bool abilityYUpdate(GamePadState state,GamePadState prestate);
	public abstract bool abilityAUpdate(GamePadState state,GamePadState prestate);
	public abstract bool abilityBUpdate(GamePadState state,GamePadState prestate);
	public abstract bool abilityXUpdate(GamePadState state,GamePadState prestate);
	public abstract void abilityUpdate(GamePadState state,GamePadState prestate);
}
