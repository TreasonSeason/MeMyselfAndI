using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
  //  public static bool IsGamePaused = false;
  //  public static bool PlayerDeaded = false;
    public GameObject deathScreen;
    
    // Start is called before the first frame update
    public void LoadMenu()
    {
    //    IsGamePaused = false;
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(0);
    }
    public void Respawn()
    {
        deathScreen.SetActive(false);
        Time.timeScale = 1;
        Application.LoadLevel(SceneManager.GetActiveScene().buildIndex);

    }
    public void LoadMainSpawn()
    {
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
        Application.LoadLevel(1);
    }

}
