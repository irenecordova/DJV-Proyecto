using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool moving;
    private double movementSpeed;
    private float jumpSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    public bool grounded;
    public bool doubleJump;
    private List<string> objects;
    public bool overClimbable;
    public bool climbing;
    public AudioClip jumpClip;
    public AudioClip DieClip;
    private AudioSource audioPlayer;
    private AudioSource audioDie;
    private AudioSource audioJump;
    private GameObject[] enemies;
    public static PlayerController player;

    void Awake()
    {
        if ( player == null ){
            player = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (player != this){
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start() {
        this.movementSpeed = 0.085;
        this.jumpSpeed = 10f;
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.moving = false;
        this.grounded = true;
        this.overClimbable = false;
        this.climbing = false;
        this.objects = new List<string>();

        audioPlayer = GetComponent<AudioSource>();
        audioDie = GetComponent<AudioSource>();
        audioJump = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.overClimbable) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && this.overClimbable && !this.climbing) {
                this.climbing = true;
                this.rb.gravityScale = (float)0;
                this.rb.velocity = new Vector2(0.0f,0.0f);
            }
            if (Input.GetKeyDown(KeyCode.Z) && this.overClimbable) {
                this.climbing = false;
                this.rb.gravityScale = (float)3;
            }
        } else {
            this.climbing = false;
            this.rb.gravityScale = (float)3;
        }

        if (this.climbing) {
            if (Input.GetKey(KeyCode.UpArrow)) {
                Vector3 position = this.transform.position;
                position.y = position.y + (float)this.movementSpeed;
                this.transform.position = position;
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                Vector3 position = this.transform.position;
                position.y = position.y - (float)this.movementSpeed;
                this.transform.position = position;
            }
        } 
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

        if (!this.climbing) {
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
        
    }

    public void Jump()
    {
        this.rb.velocity = new Vector2(this.rb.velocity.x, 0);
        this.rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        audioJump.clip = jumpClip;
        audioJump.Play();
        
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

     void OnCollisionEnter2D(Collision2D col)
    {
        var otherObject = col.collider.gameObject;

        if (otherObject.tag == "Damnific")
        {
           EnemyTouch();
        }
    }

    void PositionInitial()
    {
        this.transform.position = new Vector3(-10.48f,-3.195f,0);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject t in enemies)
        {
            t.SetActive(true);
        }
        
    }

    public void EnemyTouch(){
        audioDie.clip = DieClip;
        audioDie.Play();
        PositionInitial();
    }

    public List<string> getObjectList(){
        return this.objects;
    }

    public bool getOverClimbable() {
        return this.overClimbable;
    }

    public void setOverClimbable(bool state) {
        this.overClimbable = state;
    }

    public bool getClimbing() {
        return this.climbing;
    }

    public void setClimbing(bool state){
        this.climbing = state;
    }
}
