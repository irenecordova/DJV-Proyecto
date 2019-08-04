using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    private int lifes;
    private int totalPoints;
    private int bonusPoints;
    private bool alive;
    private bool moving;
    private double movementSpeed;
    private float jumpSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    public bool grounded;
    public bool doubleJump;

    // Start is called before the first frame update
    void Start() {
        this.lifes = 3;
        this.totalPoints = 0;
        this.bonusPoints = 0;
        this.alive = true;
        this.movementSpeed = 0.085;
        this.jumpSpeed = 10f;
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.moving = false;
        this.grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.timeScale != 0)
        {
            //this.animator.ResetTrigger("Walking Left");
            this.animator.SetTrigger("Walking Right");
            this.moving = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.timeScale != 0)
        {
            //this.animator.ResetTrigger("Walking Right");
            this.animator.SetTrigger("Walking Left");
            this.moving = true;
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            //this.animator.ResetTrigger("Walking Right");
            if (this.moving)
            {
                this.animator.SetTrigger("Idle");
                this.moving = false;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && Time.timeScale != 0)
        {
            Vector3 position = this.transform.position;
            position.x = position.x + (float)this.movementSpeed;
            this.transform.position = position;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && Time.timeScale != 0)
        {
            Vector3 position = this.transform.position;
            position.x = position.x - (float)this.movementSpeed;
            this.transform.position = position;
        }

        if (grounded)
        {
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                Jump();
                doubleJump = true;
            }
            else if (doubleJump)
            {
                Jump();
                doubleJump = false;
            }          
        }
    }

    void Jump()
    {
        this.rb.velocity = new Vector2(this.rb.velocity.x, 0);
        this.rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        var otherObject = col.collider.gameObject;

        if (otherObject.tag == "Floor")
        {
           grounded = true;
        }
    }

     void OnCollisionExit2D(Collision2D col)
    {
        var otherObject = col.collider.gameObject;

        if (otherObject.tag == "Floor")
        {
           grounded = false;
        }
    }
}
