using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour {

	Animator animator;
	private AudioSource AudioSmashed;
	public bool smashed;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		AudioSmashed = GetComponent<AudioSource>();
		smashed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Cat") {
			animator.SetBool ("IsIn", true);
			if (smashed != true) {
				AudioSmashed.Play ();
				smashed = true;
			}
		}
	}
}