using UnityEngine;
using System.Collections;
using XInputDotNetPure; 
public class PressAScript : MonoBehaviour {
	public int playerNumber;
	private PlayerIndex playerIndex;
	public Sprite sp1;
	public Sprite sp2;
	public Sprite sp3;
	public playerClass thisClass;
	private GamePadState state;
	private GamePadState pre;
	private JoinGameCam cam;
	private bool playerjoin = false;
	private bool playerReady = false;
	private bool pressedB = false;
	public GameObject background;
	public GameObject thisChar;
	public int indexor = 0;
	private int selecterCool = 0;
	private ImmortalObjectScript immortal;
	// Use this for initialization
	void Start () {
		// a = GameObject.Find ("RespawnObject").GetComponent<RespawnScript> ();
		playerIndex = (PlayerIndex)playerNumber;
		cam = GameObject.Find ("Main Camera").GetComponent<JoinGameCam> ();
		immortal = GameObject.Find ("Immortal").GetComponent<ImmortalObjectScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		state = GamePad.GetState (playerIndex, GamePadDeadZone.None);

		//join game
		if (state.Buttons.A == ButtonState.Pressed && !playerjoin) {
			thisChar.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,1);
			background.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,.1f);
			//background.GetComponent<SpriteRenderer> ().sprite = sp2;
			cam.playerJoin ();
			playerjoin = true;
		}
		//ready
		if (playerjoin && state.Buttons.Start == ButtonState.Pressed && !playerReady) {
			background.GetComponent<SpriteRenderer> ().color = new Color(.3f,.8f,.4f,.1f);
			//background.GetComponent<SpriteRenderer> ().sprite = sp3;
			cam.playerReady (playerNumber, thisClass);
			playerReady = true;
			//a.InitialSpawn (playerNumber);
		}
		//select char
		if (playerjoin && ! playerReady) {
			if (state.ThumbSticks.Left.X > .2f && selecterCool <= 0) {
				selecterCool = 30;
				indexor = (indexor + 1) % 4;
			} else if (state.ThumbSticks.Left.X < -.2f && selecterCool <= 0) {
				selecterCool = 30;
				indexor = (indexor - 1) % 4;
				if (indexor < 0)
					indexor = 3;
			} else if (selecterCool > 0)
				selecterCool--;
			thisClass = (playerClass)indexor;

			switch (indexor) {
				case 0:
					thisChar.GetComponent<IndAnim> ().current = immortal.animations [0].getSpin ();
					break;
				case 1:
					thisChar.GetComponent<IndAnim> ().current = immortal.animations [1].getSpin ();
					break;
				case 2:
					thisChar.GetComponent<IndAnim> ().current = immortal.animations [2].getSpin ();
					break;
				case 3:
					thisChar.GetComponent<IndAnim> ().current = immortal.animations [3].getSpin ();
					break;
			}
		}
		if (state.Buttons.B == ButtonState.Released) {
			pressedB = false;
		}
		//go back one 
		if (!pressedB) {
			if (state.Buttons.B == ButtonState.Pressed) {
				pressedB = true;
				if (playerReady) {
					playerReady = false;
					cam.playerNotReady (playerNumber);
					//background.GetComponent<SpriteRenderer> ().sprite = sp2;
					background.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,.1f);
				} else if (playerjoin) {
					playerjoin = false;
					cam.playerLeave ();
					//background.GetComponent<SpriteRenderer> ().sprite = sp1;
					background.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
					thisChar.GetComponent<SpriteRenderer> ().color = new Color(1,1,1,0);
					thisChar.GetComponent<IndAnim> ().clear ();
				}
			}
		}
		pre = state;
	}
	public void setPlayerNumber(int a){
		playerNumber = a;
		playerIndex = (PlayerIndex)playerNumber;
	}
}