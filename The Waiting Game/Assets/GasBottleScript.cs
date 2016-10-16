using UnityEngine;
using System.Collections;

public class GasBottleScript : MonoBehaviour {

   // public delegate void ClickAction();
  //  public static event ClickAction OnClicked;
    int i = 0;
    bool click = false, lost = false;

    // Use this for initialization
    void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

        i++;
        if (click && i > 10) {

            if (i > 10 && i < 100)
            {
                GetComponent<Animation>().Play("Flip Fail");
                lost = true;
            }

            else
            {
                GetComponent<Animation>().Play("Flip Success");
            }

            click = false;
            i = 0;

        }
	    

	}

    void OnCollisionEnter(Collision col)
    {

        if (!GetComponent<Animation>().IsPlaying("Flip Fail") && lost)
        {
            YouLost();
        }

        else
        {
            
        }
    }

    void OnMouseDown()
    {
        click = true;
    }

    void YouLost()
    {
        var go = this.gameObject;
        GameObject exp = (GameObject)Instantiate(GameObject.FindWithTag("Explosion"), go.transform.position, go.transform.rotation);
        Destroy(this.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Table"));
        go = exp;
    }
}
