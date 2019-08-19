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
    private GameObject hammerMessage;
    private GameObject shovelMessage;
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
        hammerMessage = GameObject.FindGameObjectWithTag("HammerMessage");
        shovelMessage = GameObject.FindGameObjectWithTag("ShovelMessage");
        levelName = Application.loadedLevelName;

        if (hammerMessage != null)
        {
            hammerMessage.SetActive(false);
        }
        if (shovelMessage != null)
        {
            shovelMessage.SetActive(false);
        }
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

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            this.scriptPlayer.getObjectList().Add(this.nombre);
            this.reproductor.reproducir(hammerClip);
            if (this.nombre == "martillo")
            {
                hammer.SetActive(true);
                hammerMessage.SetActive(true);
                Destroy(hammerMessage,5f);
                
            }
            else
            {
                shovel.SetActive(true);
                shovelMessage.SetActive(true);
                Destroy(shovelMessage,5f);
            }                
            Destroy(gameObject);
            
            
        }
    }

   
 
    
}
