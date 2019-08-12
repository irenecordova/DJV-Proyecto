using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductorSonidos : MonoBehaviour
{

    private AudioClip audio;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducir(AudioClip audio){
        this.source.clip = audio;
        this.source.Play();
    }
}
