using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    SpriteRenderer playerRenderer;
    bool loockingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        Debug.Log(move);

        if (move > 0 && !loockingRight)
            Flip();
        else if (move < 0 && loockingRight)
            Flip();
    }

    void Flip()
    {
        loockingRight = !loockingRight;
        playerRenderer.flipX = !playerRenderer.flipX;
    }
}
