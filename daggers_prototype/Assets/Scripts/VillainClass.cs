using UnityEngine;
using System.Collections;

public class VillainClass : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			GetComponent<NavMeshAgent> ().destination = target.transform.position;
		}
		transform.eulerAngles = new Vector3(0,0,0);
	}
}
