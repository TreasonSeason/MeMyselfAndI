using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planets : MonoBehaviour
{
    // Start is called before the first frame update


    [System.Serializable]
    public class Planet
    {
        public string name;
        public int number;
        public bool unlocked;
        public GameObject VictoryScreen;
    }
    public Planet[] planets;
    //Patikrina ar planeta su duotu scenos numeriu atrakinta

    public bool CheckIfUnlocked(int number)
    {
        Planet p = null;
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].number == number)
            {
                p = planets[i];
                break;
            }
        }
        if (p == null)
        {
            Debug.LogWarning("Planet with number " + number + " not found!");
            return false;
        }

        return p.unlocked;
    }
    //Atrakina planeta, kurios scenos numeris (numer) yra lygus duotam scenos numeriui.

    public void Unlock(int number)
    {
        Planet p = null;
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].number == number)
            {
                p = planets[i];
                break;
            }
        }
        if (p == null)
        {
            Debug.LogWarning("Planet with number " + number + " not found!");
            return;
        }
        p.unlocked = true;
    }
    //Grazina planetos numeri masyve (iesko pagal scenos numeri)
    public int GetPlanetMNumber(int SceneNumber)
    {
        int nb = -1;
        for (int i = 0; i < planets.Length; i++)
        {
            if (planets[i].number == SceneNumber)
            {
                nb = i;
                break;
            }
        }
        if (nb == -1)
        {
            Debug.LogWarning("Planet with number " + SceneNumber + " not found!");
            return -1;
        }
        return nb;
    }

    //Cia dalykas  victory screen mygtukui ir vieta planetu atrakinimui.
    public void Continue()
    {
        //nextWave = 0;
    //    VictoryScreen.SetActive(false);
        // Destroy(player);
        //  FindObjectOfType<AudioManager>().Play("Spawn");
     //   Time.timeScale = 1;
     //   int sk =  SceneManager.GetActiveScene().buildIndex;
      //  int planetNumber = GetPlanetMNumber(sk);

      //  planets.Unlock(sk+1);
        Application.LoadLevel(1);


        //BAIGESI VISOS BANGOS- ------------------------------------------------------------------------------------------------
        //Victory screen + nauja planeta atrakinta
    }
}
