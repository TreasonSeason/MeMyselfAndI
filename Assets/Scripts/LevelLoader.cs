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
            Application.LoadLevel(leveltoLoad);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerInTheZone = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerInTheZone = false;
        }
    }

}
