using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
