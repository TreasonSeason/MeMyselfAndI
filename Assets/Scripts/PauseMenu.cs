using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public static bool isSettingsOpen = false;
    public static bool isCreditsOpen = false;
    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUi;
    public GameObject Credits;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isCreditsOpen == true)
            {
                CloseCredits();
            }
            else if (IsGamePaused && isSettingsOpen == false)
            {
                Resume();
            }
            else if (isSettingsOpen == true)
            {
                CloseSettings();
            }
            else if (IsGamePaused == false && isSettingsOpen == false)
            {
                Pause();
            }
        }
    }
   public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        IsGamePaused = false;
    }
   public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        IsGamePaused = true;
    }
   public void OpenSettings()
    {
        if (isSettingsOpen == false)
        {
            SettingsMenuUi.SetActive(true);
            PauseMenuUI.SetActive(false);
            IsGamePaused = false;
            isSettingsOpen = true;
        }
    }
   public void CloseSettings()
    {
        if (isSettingsOpen == true)
        {
            SettingsMenuUi.SetActive(false);
            PauseMenuUI.SetActive(true);
            IsGamePaused = true;
            isSettingsOpen = false;
        }
    }
    public void OpenCredits()
    {
        if (isCreditsOpen == false)
        {
            Credits.SetActive(true);
            PauseMenuUI.SetActive(false);
            IsGamePaused = false;
            isCreditsOpen = true;
        }
    }
    public void CloseCredits()
    {
        if (isCreditsOpen == true)
        {
            Credits.SetActive(false);
            PauseMenuUI.SetActive(true);
            IsGamePaused = true;
            isCreditsOpen = false;
        }
    }

   public void LoadMenu()
    {
        IsGamePaused = false;
        Time.timeScale = 1f;
        Application.LoadLevel(0);
    }
   public void Disconnect()
    {
    IsGamePaused = false;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
