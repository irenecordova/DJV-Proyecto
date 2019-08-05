using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerIsAtLeft : MonoBehaviour
{
    private bool destroyable;

    // Start is called before the first frame update
    void Start()
    {
        this.destroyable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.destroyable && Input.GetKeyDown(KeyCode.X)) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.destroyable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.destroyable = false;
        }
    }
}
