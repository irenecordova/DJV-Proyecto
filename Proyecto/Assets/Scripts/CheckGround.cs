using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        var otherObject = col.collider.gameObject;

        if (otherObject.tag == "Floor")
        {
           player.grounded = true;
        }

        if (otherObject.tag == "Platform")
        {
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        var otherObject = col.collider.gameObject;

        if (otherObject.tag == "Floor")
        {
            player.grounded = false;
        }

         if (otherObject.tag == "Platform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
