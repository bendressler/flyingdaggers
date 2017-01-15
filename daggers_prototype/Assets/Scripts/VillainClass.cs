using UnityEngine;
using System.Collections;

public class VillainClass : MonoBehaviour {

	public Transform target;
	private float deathradius;
	public GameObject player;
	public int atklevel;
	public float speed;
	public GameObject goalcube;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("player");
		speed = Random.Range (6, 10);
		target = CreateTarget ().transform;
		Debug.DrawLine(transform.position, target.transform.position, Color.white, 20f);
	}

	// Update is called once per frame
	void Update () {
		GetComponent<NavMeshAgent> ().speed = speed;

		if (player.GetComponent<HeroMove>().running == true) {
			//move towards target
			if (target != null) {
				GetComponent<NavMeshAgent> ().destination = target.transform.position;
			}

			//get death radius
			deathradius = player.GetComponent<HeroMove> ().range;
			if (Vector3.Distance (gameObject.transform.position, player.transform.position) <= deathradius) {
				if (player.GetComponent<HeroMove> ().atklevel >= atklevel) {
					Destroy (gameObject);
				}
			}

			transform.eulerAngles = new Vector3 (0, 0, 0);
		}
	}

	GameObject CreateTarget(){
		float xcoord = Random.Range (-10f, 10f);
		GameObject targetcube = (GameObject) Instantiate (goalcube, new Vector3 (xcoord, 2, -4), Quaternion.identity);
		return targetcube;
	}
}
