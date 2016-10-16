using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    int delay = 5000;
    bool appLoaded = false;
    bool done = false, playing = false;
    static int i = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (!appLoaded)
        {
            

            if (done)
            {   i++;
                appLoaded = true;
                if (i == 1)
                    SceneManager.LoadScene("BottleFlip");
                else if (i == 2)
                    SceneManager.LoadScene("MiniTank/Missile-scene");
                else
                {
                    i = 0;
                }
                
            }

            else
            {
                if(!GetComponentInChildren<Animation>().IsPlaying("open") && !playing)
                    GetComponentInChildren<Animation>().Play("open");

                playing = true;
            }

            if (!GetComponentInChildren<Animation>().IsPlaying("open"))
            {
                done = true;
            }


        }

        else
        {
            GetComponentInChildren<Animation>().Play("close");
            appLoaded = false;
            }
        }

        IEnumerator MyMethod()
        {
            Debug.Log("Before Waiting 2 seconds");
            yield return new WaitForSeconds(2);
            Debug.Log("After Waiting 2 Seconds");
        }
}

