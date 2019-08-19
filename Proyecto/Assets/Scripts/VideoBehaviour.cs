using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoBehaviour : MonoBehaviour
{

    public string nextVideo;
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        this.videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += LoadScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextVideo, LoadSceneMode.Single);
    }
}
