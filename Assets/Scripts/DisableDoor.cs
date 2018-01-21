using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Cat"){
			this.GetComponent<SpriteRenderer>().enabled = false;
			this.GetComponent<BoxCollider2D>().enabled = false;
			this.GetComponent<PolyNavObstacle>().enabled = false;
		}

	}
}
