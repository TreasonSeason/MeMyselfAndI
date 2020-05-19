using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oxigenbar : MonoBehaviour
{
    public Image currentOxigenBar;
    public Text ratioText;
    public float oxigenPoints = 160;
    public float maxOxigenPoints = 200;
    public bool safezone = true;
    public float reduceOxigen = 1;
    public float damage = 5;
    public GameObject player;
    void FixedUpdate()
    {
            float ratio = oxigenPoints / maxOxigenPoints;
            currentOxigenBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            ratioText.text = (ratio * 100).ToString("0") + '%';
            // if(GameObject.FindWithTag("Player").GetComponent<Inventory>().gameObject.activeInHierarchy)
            //    GameObject.FindWithTag("StatDis").GetComponent<StatDisplays>().ValueTextUpd.text = healthPoints.ToString();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainSpawn")
        {
            safezone = true;
        }
        else safezone = false;
        if (safezone == false)
        {
            RemoveOxigen(reduceOxigen);
        }
    }
    //public void TakeDamage(float damage)
    //{
    //    oxigenPoints = oxigenPoints - damage;
    //    if (oxigenPoints <= 0)
    //    {
    //        healthPoints = 0;
    //        SceneManager.LoadScene("MainSpawn");
    //        Debug.Log("Dead!");
    //    }
    //    FixedUpdate();
    //}

    public void RestoreOxigen(float oxigen)
    {
        oxigenPoints = oxigenPoints + oxigen;
        if (oxigenPoints > maxOxigenPoints)
        {
            oxigenPoints = maxOxigenPoints;
        }
        FixedUpdate();
    }
    public void RemoveOxigen(float oxigen)
    {
        oxigenPoints = oxigenPoints - oxigen;
        if (oxigenPoints <= 0)
        {
            oxigenPoints = 0;
            player.GetComponent<healthbar>().TakeDamage(damage);
            //player.SendMessage("TakeDamage", damage);
        }
        FixedUpdate();
    }
}
