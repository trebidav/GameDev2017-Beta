using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    public string Scene;
    public bool Switch;

	// Use this for initialization
	void Start () {
        //Scene = "Tutorial";
        Switch = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Switch){
            Switch = false;
            Change();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger){
            Debug.Log("Trigger reached exit.");
        }
        else if (collision.gameObject.tag == "Cat"){
            //Change();

            StartCoroutine(Wait());
         
        }

    }

    public void Change(){
        if (Scene != "")
            UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
    }
 
    public void Quit(){
            Application.Quit();
    }

    IEnumerator Wait()
    {
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        Change();

    }
}
