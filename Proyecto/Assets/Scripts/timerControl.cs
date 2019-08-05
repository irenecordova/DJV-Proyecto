using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerControl : MonoBehaviour
{
    public GUIText timeText;
    public float  time = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time++ * Time.deltaTime;
        timeText.text = "" + time.ToString("f0");

    }
}
