using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usableObject : MonoBehaviour
{
    public string nombre;
    private GameObject player;
    private MovimientoJugador scriptPlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("MalePlayer");
        this.scriptPlayer = (MovimientoJugador) this.player.GetComponent(typeof(MovimientoJugador));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.scriptPlayer.getObjectList().Add(this.nombre);
            Destroy(gameObject);
        }
    }
    
}
