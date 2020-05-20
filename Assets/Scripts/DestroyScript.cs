using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        Invoke("Kill2", 0.05f);
    }
    public void Kill2()
    {
        Object.Destroy(gameObject);
    }
}
