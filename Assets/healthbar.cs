using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image currentHealthBar;
    public Text ratioText;
    public float healthPoints = 160;
    public float maxHealthPoints = 200;
    void Start()
    {
        //FixedUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ratio = healthPoints / maxHealthPoints;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio*100).ToString("0") + '%';
    }
    private void TakeDamage(float damage)
    {
        healthPoints = healthPoints - damage;
        if (healthPoints <= 0)
        {
            healthPoints = 0;
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Dead!");
        }
        FixedUpdate();
    }

    private void HealDamage(float health)
    {
        healthPoints = healthPoints + health;
        if (healthPoints > maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }
        FixedUpdate();
    }

}
