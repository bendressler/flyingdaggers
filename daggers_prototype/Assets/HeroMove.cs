using UnityEngine;
using System.Collections;

public class HeroMove : MonoBehaviour {

	public GameObject nextwaypoint;
	public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
	
	}
		
	// Update is called once per frame
	void Update () {
		nextwaypoint = new GameObject(GetComponent<ClickMove> ().waypoints [0]);
		if (nextwaypoint != null) {
			GetComponent<NavMeshAgent> ().destination = nextwaypoint.transform.position;
		}
		transform.eulerAngles = new Vector3(0,0,0);
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("colliding with something");
		if (col.gameObject == nextwaypoint) {
			Debug.Log ("Colliding with waypoint");
			GetComponent<ClickMove> ().waypoints.Remove (nextwaypoint);
			Destroy (nextwaypoint);
		}
	}
}
