using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformFalling : MonoBehaviour{
    private Rigidbody2D platform;
    private PolygonCollider2D polygon;
    void Start()
    {
        platform = GetComponent<Rigidbody2D>();
        polygon = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClollisionEnter2d(Collision2D col){

        if(col.gameObject.CompareTag("Player")){
            platform.isKinematic = false;
            polygon.isTrigger = true;
        }
    }
}


