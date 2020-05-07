using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplays : MonoBehaviour
{
    public Text NameText;
    public Text ValueText;
    public Text ValueTextUpd;

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        NameText = texts[0];
        ValueText = texts[1];
        //ValueTextUpd.text = GameObject.FindWithTag("Player").GetComponent<healthbar>().healthPoints.ToString();
    }
    /*public void UpdStat()
    {
        ValueTextUpd.text = GameObject.FindWithTag("Player").GetComponent<healthbar>().healthPoints.ToString();
    }*/
}
