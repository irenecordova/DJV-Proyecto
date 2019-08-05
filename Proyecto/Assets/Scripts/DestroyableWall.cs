using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWall : MonoBehaviour
{
    private bool destroyable;
    private GameObject player;
    private MovimientoJugador scriptPlayer;
    public int thickness;

    // Start is called before the first frame update
    void Start()
    {
        this.destroyable = false;
        this.player = GameObject.Find("MalePlayer");
        this.scriptPlayer = (MovimientoJugador) this.player.GetComponent(typeof(MovimientoJugador));
    }

    // Update is called once per frame
    void Update()
    {
        if (this.destroyable && Input.GetKeyDown(KeyCode.X)) {
            this.thickness -= 1;
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
