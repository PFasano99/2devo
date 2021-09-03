using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBaseMovement : MonoBehaviour
{
    GameObject[,] allGoFound = new GameObject[10,5000];
    public string[] searchAllGoByTag;
    public GameObject target;
    public float movementSpeed;

    Coroutine walkCoroutine = null;
    private void Awake()
    {
        int j = 0;
        foreach (string tag in searchAllGoByTag)
        {
            
            GameObject[] flag = GameObject.FindGameObjectsWithTag(tag);
            
            for (int i = 0; i < flag.Length; i++)
            {             
                allGoFound[j , i] = flag[i];
            }
            j++;
            
        }

        if(allGoFound[0,0] != null)
        target = getClosestTarget(allGoFound);

        if (target != null)
        {
            walkCoroutine = StartCoroutine(moveTimeTick(1f));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.1f);
    }

    void searchNextTarget()
    {

    }

    GameObject getClosestTarget(GameObject[,] goMatrix)
    {
        GameObject targetGO = null;

        float distanceFromTarget = (transform.position - goMatrix[0,0].transform.position).sqrMagnitude;
        targetGO = goMatrix[0, 0];

        for (int j = 0; j < goMatrix.GetLength(0); j++)
        {
            for (int i = 1; i < goMatrix.GetLength(1); i++)
            {
                if (goMatrix[j, i] != null)
                {
                    if (distanceFromTarget > (transform.position - goMatrix[j, i].transform.position).sqrMagnitude)
                    {
                        distanceFromTarget = (transform.position - goMatrix[j, i].transform.position).sqrMagnitude;
                        targetGO = goMatrix[j, i];
                    }
                }
                
            }
        }

        return targetGO;
    }

    IEnumerator moveTimeTick(float second)
    {

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed);
            yield return new WaitForSeconds(second);        
        }
    }
}
