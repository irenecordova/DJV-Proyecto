using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Outro : MonoBehaviour
{

    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += exitGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void exitGame(VideoPlayer vp)
    {
        Application.Quit();
    }
}
