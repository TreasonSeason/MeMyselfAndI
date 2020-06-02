using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Credit;
    public GameObject Menu;
    public bool MenuOpened = true;
    public bool IsCreditsOpen = false;
    public void OpenCredits()
    {
        if (IsCreditsOpen == false)
        {
            Credit.SetActive(true);
            Menu.SetActive(false);
           // PauseMenuUI.SetActive(false);
        //    IsGamePaused = false;
            IsCreditsOpen = true;
        }
    }
    public void CloseCredits()
    {
        if (IsCreditsOpen == true)
        {
            Credit.SetActive(false);
            Menu.SetActive(true);
            IsCreditsOpen = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsCreditsOpen == true)
            {
                CloseCredits();
            }
        }
    }
}
