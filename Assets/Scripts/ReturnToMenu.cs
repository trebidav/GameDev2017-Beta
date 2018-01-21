﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.F1)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        }
	}
}