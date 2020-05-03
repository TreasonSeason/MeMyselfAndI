using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangeriousBlockDamage : MonoBehaviour
{
    private bool PlayerInTheZone = false;
    //public Collider2D player;
    public GameObject player;
    //public float Damage = 1;
    public float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInTheZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInTheZone == true)
        {

            //  player.SavePlayer();
            // Debug.Log("Dead!");
                player.SendMessage("TakeDamage", damage);
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
            // other.GetComponent<PlayerS>().SavePlayer();
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
    //public int damage = 1;

    //// public float damage = 1;

    //private void OnTriggerStay2D(Collider2D player)
    //{
    //    while(player.tag == "Player")
    //    {
    //        player.SendMessage("TakeDamage", damage);
    //    }
    //}
}
