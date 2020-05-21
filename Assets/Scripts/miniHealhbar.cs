using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniHealhbar : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 localScale;
    public enemyHealth eneH;
    public float multiplier = 1f;
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = eneH.health / eneH.getMaxHealth()*multiplier;
        transform.localScale = localScale;
    }
}
