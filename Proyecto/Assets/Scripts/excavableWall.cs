using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class excavableWall : MonoBehaviour
{
    private bool excavable;
    private GameObject player;
    private PlayerController scriptPlayer;
    public AudioClip shovelingClip;
    private ReproductorSonidos reproductor;
    private GameObject destroyableMessage1;
    private GameObject destroyableMessage2;
    private GameObject destroyableMessage3;
    private GameObject destroyableMessage4;
    
    // Start is called before the first frame update
    void Start()
    {
        this.excavable = false;
        this.player = GameObject.Find("MalePlayer");
        this.scriptPlayer = (PlayerController) this.player.GetComponent(typeof(PlayerController));
        this.reproductor = (ReproductorSonidos)  GameObject.Find("ReproductorSonidos").GetComponent(typeof(ReproductorSonidos));
        destroyableMessage1 = GameObject.FindGameObjectWithTag("Destroyable1");
        destroyableMessage2 = GameObject.FindGameObjectWithTag("Destroyable2");
        destroyableMessage3 = GameObject.FindGameObjectWithTag("Destroyable3");
        destroyableMessage4 = GameObject.FindGameObjectWithTag("Destroyable4");
        if (destroyableMessage1 != null)
        {
            destroyableMessage1.SetActive(false);
        }
        if (destroyableMessage2 != null)
        {
            destroyableMessage2.SetActive(false);
        }
        if (destroyableMessage3 != null)
        {
            destroyableMessage3.SetActive(false);
        }
        if (destroyableMessage4 != null)
        {
            destroyableMessage4.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.excavable && Input.GetKeyDown(KeyCode.C)) {
            this.reproductor.reproducir(shovelingClip);
            
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && this.scriptPlayer.getObjectList().Contains("pala")) {
            this.excavable = true;
            destroyableMessage4.SetActive(true);
            Destroy(destroyableMessage4,5f);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.excavable = false;
        }
    }
}
