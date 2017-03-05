using UnityEngine;
using System.Collections;
using XInputDotNetPure; 
using UnityEngine.SceneManagement;

public enum animationState {walk = 0,still = 1,falling = 2, x = 3,y = 4, a = 5, b = 6, spin = 7 };
public enum playerClass {Rogue = 0,Mage = 1,Tank = 2,Ranged = 3,Null = 5};
public enum effect {Root = 0, Stun = 1, Poison = 3, Blind = 4, Null = 5}


public class ImmortalObjectScript : MonoBehaviour {
	public arr[] animations;
	private playerClass[] players;
	public GameObject[] Players;
	private  int curlvl = 0;
	private int count = 0;
	public GameObject currentBossGameobject;
	private int menuLevel;
	public GameObject playerFab;
	void Start (){
		Players = new GameObject[4];
		menuLevel = SceneManager.GetActiveScene ().buildIndex;
		GameObject.DontDestroyOnLoad (gameObject);
		foreach (arr item in animations) {
			item.call ();
		}
	}

	void OnLevelWasLoaded(int level) {
		curlvl = level;
		if (curlvl > menuLevel) {
			for (int i = 0; i < players.Length; i++) {
				if (players [i] != playerClass.Null) {
					Players [i] = (Instantiate (playerFab, Vector3.zero, Quaternion.identity)as GameObject);
					Players [i].GetComponent<PlayerController> ().setPlayer (i, players [i]);
				}
			}
		}
	}

	public playerClass[] getPlayers(){
		return players;
	}
	public void setPlayers(playerClass[] a){
		players = a;
	}
}

[System.Serializable]
public class Effect{
	public Effect(effect e, int t){
		effect = e;
		time = t;
	}
	public effect  effect;
	public int time;
}

[System.Serializable]
public class arr{
	public string Name;
	public Texture2D walkSheet;
	public Texture2D spinSheet;
	public Texture2D idleSheet;
	public Texture2D fallSheet;
	public Texture2D abilityXSheet;
	public Texture2D abilityYSheet;
	public Texture2D abilityBSheet;
	public Texture2D abilityASheet;
	private Sprite[] walk;
	private Sprite[] spin;
	private Sprite[] idle;
	private Sprite[] fall;
	private Sprite[] abilityX;
	private Sprite[] abilityY;
	private Sprite[] abilityB;
	private Sprite[] abilityA;

	public Sprite[] getWalk(){
		return walk;
	}
	public Sprite[] getSpin(){
		return spin;
	}
	public Sprite[] getIdle(){
		return idle;
	}
	public Sprite[] getFall(){
		return fall;
	}
	public Sprite[] getAbilityX(){
		return abilityX;
	}
	public Sprite[] getAbilityY(){
		return abilityY;
	}
	public Sprite[] getAbilityB(){
		return abilityB;
	}
	public Sprite[] getAbilityA(){
		return abilityA;
	}
	public void call() {
		if(walkSheet)
			walk = Resources.LoadAll<Sprite> (walkSheet.name);
		if(spinSheet)
			spin = Resources.LoadAll<Sprite> (spinSheet.name);
		if(idleSheet)
			idle = Resources.LoadAll<Sprite> (idleSheet.name);
		if(fallSheet)
			fall = Resources.LoadAll<Sprite> (fallSheet.name);
		if(abilityXSheet)
			abilityX = Resources.LoadAll<Sprite> (abilityXSheet.name);
		if(abilityYSheet)
			abilityY = Resources.LoadAll<Sprite> (abilityYSheet.name);
		if(abilityASheet)
			abilityA = Resources.LoadAll<Sprite> (abilityASheet.name);
		if(abilityBSheet)
			abilityB = Resources.LoadAll<Sprite> (abilityBSheet.name);
	}
}

