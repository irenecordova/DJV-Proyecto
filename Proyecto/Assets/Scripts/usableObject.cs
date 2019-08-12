using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usableObject : MonoBehaviour
{
    public string nombre;
    private GameObject player;
    private PlayerController scriptPlayer;
    public AudioClip hammerClip;
    private AudioSource pickUpHammer;
    

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("MalePlayer");
        this.scriptPlayer = (PlayerController) this.player.GetComponent(typeof(PlayerController));
        this.pickUpHammer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.scriptPlayer.getObjectList().Add(this.nombre);
            this.pickUpHammer.clip = this.hammerClip;
            this.pickUpHammer.Play();
            Destroy(gameObject);
            
            
        }
        
    }

    /* IEnumerator WaitTime(){
        yield return new WaitForSeconds(2);
    } */
    
}
