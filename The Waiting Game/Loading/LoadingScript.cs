using UnityEngine;
using System.Collections;

public class LoadingScript : MonoBehaviour {
	public GameObject Starter;
	public GameObject Cyllinder;
	public GameObject End;
	public float scale;
	public float Distance;
	public float finalPosition;
	float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time = Random.Range (1000, 2000);
		while (time>0) {
			time--;
		}
		if (End.transform.position.x < finalPosition) {
			End.transform.position = new Vector3 (End.transform.position.x + Distance/100f, End.transform.position.y, End.transform.position.z);
			Cyllinder.transform.position = new Vector3(((Starter.transform.position.x + End.transform.position.x)/2f),Cyllinder.transform.position.y, Cyllinder.transform.position.z);
			Cyllinder.transform.localScale = new Vector3 (38f, scale*(End.transform.position.x - Starter.transform.position.x),38f); 
		}
	}
}
