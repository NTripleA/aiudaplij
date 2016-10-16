using UnityEngine;
using System.Collections;

public class TankCollision : MonoBehaviour {

	// Use this for initialization
	public GameObject Bullet;
	Rigidbody Tank;
	public int speed;
	public int center;
	public static float right_limit = 100;
	public static float left_limit = -100;
	Vector3 position_left;
	Vector3 position_right;
	public static int TankLifes = 3;
	private int reset;
	public int reset_value;

	void Start(){
		Tank = GetComponent<Rigidbody> ();
		position_left = new Vector3(left_limit,5,0);
		position_right = new Vector3 (right_limit,5,0);
	}

	void OnTriggerEnter (Collider Other) {
		if (Other.CompareTag("Missile")) {
			TankLifes -=1;
			Destroy(Other.gameObject);
			if(TankLifes==0){
				speed = 0;
                Destroy(this.gameObject);
			}

		}
	}

	void Update(){
		if (TankLifes > 0) {
			if (Input.GetButton ("Jump") && reset == 0){
				Instantiate (Bullet, Tank.transform.position, Quaternion.identity);
				GetComponent<AudioSource>().Play();
				reset = reset_value;
			}
			if(reset > 0){
				reset--;
			}
			float x = Input.GetAxis ("Horizontal");
			Tank.velocity = new Vector2 (speed * x, 0);
			if (Tank.position.x > right_limit || Tank.position.x < left_limit) {
				if (Tank.position.x < left_limit) {
					Tank.transform.position = position_left;
				} else {
					Tank.transform.position = position_right;
				}
			}
		}
	}
	
	// Update is called once per frame

}
