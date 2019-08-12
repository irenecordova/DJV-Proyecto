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
    
    // Start is called before the first frame update
    void Start()
    {
        this.excavable = false;
        this.player = GameObject.Find("MalePlayer");
        this.scriptPlayer = (PlayerController) this.player.GetComponent(typeof(PlayerController));
        this.reproductor = (ReproductorSonidos)  GameObject.Find("ReproductorSonidos").GetComponent(typeof(ReproductorSonidos));
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
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.excavable = false;
        }
    }
}
