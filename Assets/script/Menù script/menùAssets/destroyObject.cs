using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.tag == "rawResource")
            {
                GameObject resource = collision.gameObject;
                Destroy(resource);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
}
