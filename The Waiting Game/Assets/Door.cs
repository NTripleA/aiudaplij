using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    int delay = 5000;
    static bool appLoaded = false;
    int i = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (appLoaded == false)
        {
            GetComponent<Animation>().Play("open");
            if (!GetComponent<Animation>().IsPlaying("open"))
            {
                Application.LoadLevel("BottleFlip");
                i++;
            }

            appLoaded = true;
        }

        else
        {
            GetComponent<Animation>().Play("close");
            }
        }
	}

