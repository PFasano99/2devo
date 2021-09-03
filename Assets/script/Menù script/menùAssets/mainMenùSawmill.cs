using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenùSawmill : MonoBehaviour
{
    public Transform deliveryPoint;
    public GameObject gameObject;
    private Coroutine craftRoutine = null;
    // Start is called before the first frame update
    void Start()
    {
        craftRoutine = StartCoroutine(productionTimeTick(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator productionTimeTick(GameObject gameObject)
    {
        while (true)
        {           
                yield return new WaitForSeconds(3);
                actualCraft(gameObject);         
            //StopCoroutine(craftRoutine);
        }
    }


    public void actualCraft(GameObject toSpawn)
    {
        GameObject gameObject = (GameObject)Instantiate(toSpawn, deliveryPoint.position, Quaternion.identity);
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
