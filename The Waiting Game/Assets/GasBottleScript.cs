using UnityEngine;
using System.Collections;

public class GasBottleScript : MonoBehaviour {

   // public delegate void ClickAction();
  //  public static event ClickAction OnClicked;
    int i = 0;
    bool click = false;
    public static bool lost = false;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        i++;
        if (click) {

            if (i < 100)
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
            Debug.Log("oncolli");
        }

        if(!GetComponent<Animation>().IsPlaying("Flip Success") && !lost)
        {
            //  YouWon();
            long time = 50000;
            while(time != 0)
            {
                time--;
            }

            Application.LoadLevel("Door");
        }       

    }

    void OnMouseDown()
    {
        click = true;
    }

    void YouLost()
    {
        Destroy(this.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Table"));
        lost = true;
       
    }

    void YouWon()
    {   
        Destroy(this.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Table"));
      //  Spawn();
        

    }

    public void Spawn()
    {

        Instantiate(GameObject.Find("TitleGUI"));
        
    }
}
