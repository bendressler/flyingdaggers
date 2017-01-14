using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour {

	public GameObject marker;
	public GameObject hero;
	public int maxwpnts;
	public ArrayList waypoints = new ArrayList();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonUp (0)) {
			if (Physics.Raycast (ray, out hit, 100)) {
				if ((hit.collider.CompareTag ("terrain")) && (!hit.collider.CompareTag ("barrier"))) {
					Debug.Log ("Creating waypoint");
					GameObject waypoint = (GameObject) Instantiate (marker, hit.point, Quaternion.identity);
					hero.GetComponent<HeroMove>().nextwaypoint = waypoint;
					waypoints.Add (waypoint);
					Debug.Log(waypoints.Count);
				}
			}
		}
	}
}
