using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    private Animator animator;
    public float walkingSpeed;
  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = body.velocity;
        var speed = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed += -walkingSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed += +walkingSpeed;
        }

        v.x = speed;
        body.velocity = v;

        animator.SetFloat("moveSpeed", Mathf.Abs(speed) );
    }

}
