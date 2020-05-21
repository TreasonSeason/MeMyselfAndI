using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplays : MonoBehaviour
{
    //public Text NameText;
    //public Text ValueText;
    public Text ValueTextUpdHealth;
    public Text ValueTextUpdDmg;
    public Text ValueTextUpdOxygen;
    public Text ValueTextUpdArmor;

    private void OnValidate()
    {
        //Text[] texts = GetComponentsInChildren<Text>();
        //NameText = texts[0];
        //ValueText = texts[1];
        //ValueTextUpd.text = GameObject.FindWithTag("Player").GetComponent<healthbar>().healthPoints.ToString();
       /* ValueTextUpdHealth.text = GameObject.FindWithTag("Player").GetComponent<healthbar>().maxHealthPoints.ToString();
        ValueTextUpdOxygen.text = GameObject.FindWithTag("Player").GetComponent<oxigenbar>().maxOxigenPoints.ToString();
        ValueTextUpdDmg.text = GameObject.FindWithTag("Player").GetComponent<MultiplierStats>().damageMultiplier.ToString();
        ValueTextUpdArmor.text = GameObject.FindWithTag("Player").GetComponent<MultiplierStats>().resistenceMultiplier.ToString();*/
    }
    void Update()
    {
        ValueTextUpdHealth.text = GameObject.FindWithTag("Player").GetComponent<healthbar>().maxHealthPoints.ToString();
        ValueTextUpdOxygen.text = GameObject.FindWithTag("Player").GetComponent<oxigenbar>().maxOxigenPoints.ToString();
        ValueTextUpdDmg.text = GameObject.FindWithTag("Player").GetComponent<MultiplierStats>().damageMultiplier.ToString();
        ValueTextUpdArmor.text = GameObject.FindWithTag("Player").GetComponent<MultiplierStats>().resistenceMultiplier.ToString();
    }
}
