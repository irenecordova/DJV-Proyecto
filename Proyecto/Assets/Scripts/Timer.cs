using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 0.0f;
    public Text txt;
    public Canvas canvas;
    public static Timer timer;

    void Awake()
    {
        if ( timer == null ){
            timer = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
        }
        else if (timer != this){
            Destroy(gameObject);
            Destroy(canvas);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        /* Canvas canvas = CanvasGameOver.GetComponent<Canvas>(); */
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            canvas.enabled = true;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
        else
        {
            txt.GetComponent<Text>().text = "" + time.ToString("f0");
        }
        
    }
}
