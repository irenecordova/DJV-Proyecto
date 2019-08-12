using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbableObject : MonoBehaviour
{

    private GameObject player;
    private PlayerController scriptPlayer;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("MalePlayer");
        this.scriptPlayer = (PlayerController) this.player.GetComponent(typeof(PlayerController));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.scriptPlayer.setOverClimbable(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.scriptPlayer.setOverClimbable(false);
        }
    }
}
