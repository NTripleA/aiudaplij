using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

	AudioSource sound;
	Rigidbody Rocket;
	public int Rocket_Speed;
	private int RocketLifes = 3;
	public float scale;
	// Use this for initialization
	void Start () {
		Rocket = GetComponent<Rigidbody> ();
		Rocket.velocity = new Vector3 (0, Rocket_Speed, 0);
		Rocket.transform.Rotate(new Vector3(0,0,180));
		Rocket.transform.localScale = new Vector3 (scale, scale, scale);

		}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider Other) {
		if (Other.CompareTag ("Ground")) {
			GetComponent<AudioSource>().Play();
			TankCollision.TankLifes--;
	//		Instantiate(explosion, this.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
		if (Other.CompareTag ("Bullet")) {
			Destroy (Other.gameObject);
			RocketLifes -= 1;
			if (RocketLifes == 0) {
				GetComponent<AudioSource>().Play();
				Destroy (this.gameObject);
			}
		}
	}
}