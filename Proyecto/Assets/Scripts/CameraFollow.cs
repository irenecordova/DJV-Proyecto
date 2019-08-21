using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
    

{
    /* public float xMargin = 1f;
    public float yMargin = 1f;
    public float xSmooth = 0f;
    public float ySmooth = 0f;
    public Vector2 maxXandY;
    public Vector3 minXandY;

    private Transform character; */
    
    
    private GameObject character;
    public Vector2 minCameraPosition, maxCameraPosition;
    public float smoothTime;
    private Vector2 velocity; 
    
    void Start()
    {
       /*  character = GameObject.FindGameObjectWithTag("Player").transform; */
        character = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        /* trackPlayer(); */
    }

   

    
    /* private bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - character.position.x)> xMargin;
    }

     private bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - character.position.y)> yMargin;
    } */


    // Update is called once per frame
    void FixedUpdate()
    {
         float positionX = Mathf.SmoothDamp(transform.position.x,
         character.transform.position.x, ref velocity.x, smoothTime);
        float positionY = Mathf.SmoothDamp(transform.position.y,
         character.transform.position.y, ref velocity.y, smoothTime);
        

        transform.position= new Vector3(
            Mathf.Clamp(positionX, minCameraPosition.x, maxCameraPosition.x),
            Mathf.Clamp(positionY, minCameraPosition.y, maxCameraPosition.y),
            transform.position.z); 
            
    }

     /* private void trackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if(CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, character.position.x , xSmooth*Time.deltaTime);
        }

        if(CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, character.position.y , ySmooth*Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
        targetY = Mathf.Clamp(targetY, minXandY.y , maxXandY.y);
        
        transform.position = new Vector3 (targetX,targetY, transform.position.x);
    } */
}

