using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Level {

	public int lvl;
	public float speed;
	public float range;
	public Sprite spr;

	public Level(int newLvl, float newSpeed, float newRange, Sprite newSprite){
		lvl = newLvl;
		speed = newSpeed;
		range = newRange;
		spr = newSprite;
	}

}

public class HeroMove : MonoBehaviour {


	//general variables 
	public SpriteRenderer sprender;
	public GameObject rarender;
	public bool running;
	public int maxpoints;
	public Sprite atk0;
	public Sprite atk1;
	public Sprite atk2;
	public Sprite atk3;
	public Sprite atk4;

	//movement variables
	public GameObject nextwaypoint;
	public float speed;
	public float acceleration;

	//combat variables
	public float range;
	public int atklevel;
	Dictionary<int,Level> levels = new Dictionary<int,Level>();

	// Use this for initialization
	void Start () {
		Level level1 = new Level(1,12,1.5f,atk0);
		Level level2 = new Level(2,10,1.75f,atk1);
		Level level3 = new Level(3,6,2,atk2);
		Level level4 = new Level(4,3,3,atk3);
		Level level5 = new Level(5,1,5,atk4);
		levels.Add (1, level1);
		levels.Add (2, level2);
		levels.Add (3, level3);
		levels.Add (4, level4);
		levels.Add (5, level5);
		atklevel = 2;
		SetLevel ();
		running = false;
		maxpoints = 5;

	}
		
	// Update is called once per frame
	void Update () {

		if (GetComponent<ClickMove> ().waypoints.Count >= maxpoints) {
			running = true;
		}

		//change atklevel with arrow keys
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			if (atklevel > 1) {
				atklevel -= 1;
				SetLevel ();
			}
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			if (atklevel < 5) {
				atklevel += 1;
				SetLevel ();
			}
		}

		if (running == true) {
			//set next waypoint as navigation target
			if (GetComponent<ClickMove> ().waypoints.Count != 0) {
				nextwaypoint = ((GameObject)GetComponent<ClickMove> ().waypoints [0]).gameObject;
			}
			if (nextwaypoint != null) {
				GetComponent<NavMeshAgent> ().destination = nextwaypoint.transform.position;
			}

		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject == nextwaypoint) {
			GetComponent<ClickMove> ().waypoints.Remove (nextwaypoint);
			Destroy (nextwaypoint);
		}
	}

	void LateUpdate(){
		transform.eulerAngles = new Vector3(0,0,0);
	}

	void SetLevel(){
		range = levels [atklevel].range;
		speed = levels [atklevel].speed;
		GetComponent<NavMeshAgent> ().speed = speed;
		sprender.sprite = UpdateSprite (atklevel); 
		rarender.transform.localScale = new Vector3 (range,0,range);
	}

	//adjust sprite based on attack level
	Sprite UpdateSprite(float atk){
		Sprite atksprite = sprender.sprite;
		if (atk == 1) {
			atksprite = atk0;
		} else if (atk == 2) {
			atksprite = atk1;
		} else if (atk == 3) {
			atksprite = atk2;
		} else if (atk == 4) {
			atksprite = atk3;
		} else if (atk == 5) {
			atksprite = atk4;
		} 
		return atksprite;
		
	}
}
