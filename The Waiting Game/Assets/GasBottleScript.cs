using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GasBottleScript : MonoBehaviour {

   // public delegate void ClickAction();
  //  public static event ClickAction OnClicked;
    int i = 0;
    bool click = false;
    public static bool lost = false;
    public GameObject go;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        this.go = go;
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
            
            StartCoroutine(MyMethod());
            SceneManager.LoadScene("Door");
        }       

    }

    public void OnMouseDown()
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
        Spawn();
        

    }

    public void Spawn()
    {

        go.SetActive(true);
        
    }

    IEnumerator MyMethod()
    {
        YouWon();
        Debug.Log("Before Waiting 2 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("After Waiting 2 Seconds");
    }
}
