using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScreech : MonoBehaviour {
	private AudioSource AudioScreech;
	public bool screeched;

	void Start(){

		AudioScreech = GetComponent<AudioSource>();
		screeched = false;

	}

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Cat" && screeched != true){
				AudioScreech.Play ();
				screeched = true;
				Debug.Log("I screeched!");
			}
		}
	
}
