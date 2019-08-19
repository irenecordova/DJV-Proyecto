using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class usableObject : MonoBehaviour
{
    public string nombre;
    private GameObject player;
    private GameObject hammer;
    private GameObject shovel;
    private PlayerController scriptPlayer;
    public AudioClip hammerClip;
    private ReproductorSonidos reproductor;
    private string levelName;
    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("MalePlayer");
        shovel = GameObject.FindGameObjectWithTag("Shovel");
        this.scriptPlayer = (PlayerController) this.player.GetComponent(typeof(PlayerController));
        this.reproductor = (ReproductorSonidos)  GameObject.Find("ReproductorSonidos").GetComponent(typeof(ReproductorSonidos));
        hammer = GameObject.FindGameObjectWithTag("Hammer");
        shovel = GameObject.FindGameObjectWithTag("Shovel");
        levelName = Application.loadedLevelName;
        if (hammer != null)
        {
            hammer.SetActive(false);
        }
        if (shovel != null)
        {
            shovel.SetActive(false);
        }
        if (levelName == "Nivel 2")
        {
            hammer.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            StartCoroutine(WaitTime());
            print("hola");
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.scriptPlayer.getObjectList().Add(this.nombre);
            this.reproductor.reproducir(hammerClip);
            if (this.nombre == "martillo")
            {
                hammer.SetActive(true);
                StartCoroutine(WaitTime());
                print("gola");
                flag = true;
                
            }
            else
            {
                shovel.SetActive(true);
            }                
            Destroy(gameObject);
            
            
        }
    }

    IEnumerator WaitTime()
    {
        flag = false;
        //Do some stuff here while we wait
        yield return new WaitForSeconds(5);
        //my code here after 3 seconds
        print("hola");
    }
 
    
}
