using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogBehaviour : MonoBehaviour
{
    public string nextScene;
    private GameObject mensaje;

    // Start is called before the first frame update
    void Start()
    {
        this.mensaje = GameObject.Find("Mensaje");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.mensaje.transform.position = new Vector3(-22f,-8f,0);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
    }

}
