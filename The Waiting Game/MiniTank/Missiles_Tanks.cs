using UnityEngine;
using System.Collections;

public class Missiles_Tanks : MonoBehaviour {

	// Use this for initialization
	public GameObject Rocket;
	public GameObject Tank;
	public float min_time;
	public float max_time;
	private int time = 100;
	Vector3 position;

	void Start () {
//		ScreenOrientation.Portrait();
	}
	
	// Update is called once per frame

	void Update () {
		if (TankCollision.TankLifes == 0) {
			YouLost();
			Destroy(this.gameObject);
		}
		position = new Vector3 (Random.Range(TankCollision.left_limit, TankCollision.right_limit), 200, 0);
		time--;
		if (time == 0) {
			time = (int)Random.Range (min_time, max_time);
			Instantiate (Rocket, position, Quaternion.identity);
		}
	}

	void YouLost(){

	}

}
