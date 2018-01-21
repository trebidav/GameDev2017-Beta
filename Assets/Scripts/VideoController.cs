using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour {

    private UnityEngine.Video.VideoPlayer player;
    public string scene = "Menu";
	// Use this for initialization
	void Start () {

        player = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        player.isLooping = true;
        player.loopPointReached += EndReached;
        player.playbackSpeed = 1;
        player.Play();
       
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }



}
