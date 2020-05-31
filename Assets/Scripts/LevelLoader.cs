using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private bool PlayerInTheZone;
    public int leveltoLoad;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInTheZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInTheZone)
        {
            //  player.SavePlayer();
          //  FindObjectOfType<AudioManager>().Play("Spawn");
            Application.LoadLevel(leveltoLoad);
         //   FindObjectOfType<AudioManager>().Play("Spawn");
            // this.GetComponent<PlayerS>().LoadPlayer();
            // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerS>().LoadPlayer();
            //  player.LoadPlayer();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerInTheZone = true;
            other.GetComponent<PlayerS>().SavePlayer();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerInTheZone = false;
            //other.GetComponent<PlayerS>().LoadPlayer();
        }
    }

}
