using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMenager : MonoBehaviour
{
    public enum ResourceTypes { Wood, Stone, Food, Radioactive, Water, Iron, Fiber, Population, coal, copper };
    public ResourceTypes resourceTypes;

    public int resourceHealt;
    private float availableResource; //act as resource healt

    public GameObject toSpawn1, toSpawn2;

    public int ResourceHealt { get => resourceHealt; set => resourceHealt = value; }
    public float AvailableResource { get => availableResource; set => availableResource = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceHealt < 1)
        {
            Destroy(gameObject);
            float change = 0.6f;
            Vector3 position = transform.position;
            position = new Vector3(transform.position.x, transform.position.y + change, (transform.position.y + change)*0.1f);
            Instantiate(toSpawn1, position, Quaternion.identity);
            Debug.Log("object 2 "+ toSpawn2.ToString());
            if (toSpawn2.Equals(null) == false)
            {
                position = new Vector3(transform.position.x, transform.position.y - change, (transform.position.y - change) * 0.1f);
                Instantiate(toSpawn2, position, Quaternion.identity);
            }
            
        }
    }

   

}
