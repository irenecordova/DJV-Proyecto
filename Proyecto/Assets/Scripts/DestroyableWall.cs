﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWall : MonoBehaviour
{
    private bool destroyable;
    private GameObject player;
    private PlayerController scriptPlayer;
    public int thickness;
    public AudioClip destroyClip;
    private ReproductorSonidos reproductor;


    // Start is called before the first frame update
    void Start()
    {
        this.destroyable = false;
        this.player = GameObject.Find("MalePlayer");
        this.scriptPlayer = (PlayerController) this.player.GetComponent(typeof(PlayerController));
        this.reproductor = (ReproductorSonidos)  GameObject.Find("ReproductorSonidos").GetComponent(typeof(ReproductorSonidos));
    }

    // Update is called once per frame
    void Update()
    {
        if (this.destroyable && Input.GetKeyDown(KeyCode.X)) {
            this.thickness -= 1;
            this.reproductor.reproducir(destroyClip);
            
            if (this.thickness == 0) Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && this.scriptPlayer.getObjectList().Contains("martillo")) {
            this.destroyable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.destroyable = false;
        }
    }
}
