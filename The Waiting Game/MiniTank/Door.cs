using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	// Use this for initialization
	public int speed;
	Rigidbody door;
	void Start () {
		door = GetComponent<Rigidbody> ();
		door.velocity = new Vector2 (speed, 0);
	}

}
