using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public int bullet_speed;
	Rigidbody bullet;
	// Use this for initialization
	void Start () {
		bullet = GetComponent<Rigidbody>();
		bullet.velocity = new Vector3 (0, bullet_speed, 0);
		bullet.transform.localScale = new Vector3 (400, 400, 400);
		bullet.transform.Rotate(new Vector3(-90,0,0));
	}
	
	// Update is called once per frame
	void Update(){
		if (bullet.transform.position.y > 200) {
			Destroy (this.gameObject);
		}
	}

}
