using UnityEngine;
using System.Collections;
using XInputDotNetPure;
public abstract class Ability {
	public int damage = 0;
	public abstract void abilityUpdate(GamePadState state,GamePadState prestate);
}
