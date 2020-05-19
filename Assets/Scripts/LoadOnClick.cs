using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour
{
    // public Animator musicAnim;
    // public int waitTime = 2;
    // public void LoadScene(int level)
    // {
    // Application.LoadLevel(level);
    //   StartCoroutine(ChangeScene);
    //  }
    public Animator musicAnim;
    public int waitTime = 2;

    public void Wrapper(int level)
    {
        StartCoroutine(ChangeScene(level));
    }
    IEnumerator ChangeScene(int level)
    {
      //  Animator musicAnim = GameObject.FindWithTag("BG_Music");
        musicAnim.SetTrigger("StartToFade");
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel(level);
    }
}
