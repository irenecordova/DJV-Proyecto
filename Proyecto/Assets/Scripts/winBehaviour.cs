using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winBehaviour : MonoBehaviour
{
    public AudioClip audio;
    private ReproductorSonidos reproductor;

    // Start is called before the first frame update
    void Start()
    {
        this.reproductor = (ReproductorSonidos)  GameObject.Find("ReproductorSonidos").GetComponent(typeof(ReproductorSonidos));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.reproductor.reproducir(audio);
        }
    }
}
