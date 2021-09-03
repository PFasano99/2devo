using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class builderMenager : MonoBehaviour
{
    public Coroutine positionRoutine;
    public bool canBePlaced = false;
    private bool toSub = true;
    
    private ContactFilter2D contactFilter;
    private List<Collider2D> results = new List<Collider2D>(10);

    private string resourceType;

    public void setResourceType(string value)
    {
        resourceType = value;
    }
    public void createBuilding(GameObject toSpawn, string resource)
    {
        resourceType = resource;
        canBePlaced = false;
        
        if (FindObjectOfType<resourceQuantity>().getNoFilter() > 0 && resource.Equals("noFilter"))
            actualCreate(toSpawn);       
        else if (FindObjectOfType<resourceQuantity>().getDeposit() > 0 && resource.Equals("deposit"))
            actualCreate(toSpawn);      
        else if (FindObjectOfType<resourceQuantity>().getSawmill() > 0 && resource.Equals("sawmill"))
            actualCreate(toSpawn);
        else if (FindObjectOfType<resourceQuantity>().getShop() > 0 && resource.Equals("shop"))
            actualCreate(toSpawn);
        else if (FindObjectOfType<resourceQuantity>().getMeccanic() > 0 && resource.Equals("meccanic"))
            actualCreate(toSpawn);
        else if (FindObjectOfType<resourceQuantity>().getBlacksmith() > 0 && resource.Equals("blacksmith"))
            actualCreate(toSpawn);
        else if (FindObjectOfType<resourceQuantity>().getArchitect() > 0 && resource.Equals("architect"))
            actualCreate(toSpawn);
        else if (FindObjectOfType<resourceQuantity>().getPower() > 0 && resource.Equals("power"))
            actualCreate(toSpawn);
    }

    public void actualCreate(GameObject toSpawn)
    {
        Vector3 mousePosition = getMousePosition();
        GameObject newObject = Instantiate(toSpawn, mousePosition, Quaternion.identity);
        toSub = true;
        positionRoutine = StartCoroutine(changePositionTick(newObject));
    }

    public Vector3 getMousePosition()
    {
        //codice per settare la posizione del mouse 
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        return rayPoint;
    }

    IEnumerator changePositionTick(GameObject toMove)
    {
        while (true)
        {

            do
            {
               
               yield return new WaitForSeconds(0.01f);
               toMove.transform.position = getMousePosition();
               if(Input.GetKeyDown(KeyCode.Mouse0))
                {                    
                    canBePlaced = isColliding(toMove.GetComponent<Collider2D>());
                    if(canBePlaced)
                    toMove.gameObject.GetComponent<buildingMenager>().isPlaced = true;
                    FindObjectOfType<buildingMenager>().setZ();
                }
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Destroy(toMove);
                    StopCoroutine(positionRoutine);
                }

            } while (!canBePlaced);
        
            StopCoroutine(positionRoutine);

            if(toSub)
            subResource(resourceType);
            
        }
    }

    public bool isColliding(Collider2D collider)
    {
     
        int c = collider.OverlapCollider(contactFilter.NoFilter(), results);
        if (c == 1)
        {
            return true;
        }
        else if (c <= 2 && (resourceType.Equals("deposit") || resourceType.Equals("shop") || resourceType.Equals("sawmill") || resourceType.Equals("blacksmith") || resourceType.Equals("meccanic") || resourceType.Equals("architect") || resourceType.Equals("power")))
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

    public void subResource(string resource)
    {
        if(resource.Equals("noFilter"))
            FindObjectOfType<resourceQuantity>().setNoFilter(FindObjectOfType<resourceQuantity>().getNoFilter() - 1);
        
        FindObjectOfType<architectMenager>().actualCraft(resource, -1);

        FindObjectOfType<resourceQuantity>().setCurrentQuantity(FindObjectOfType<resourceQuantity>().getCurrentQuantity() - 1);
        canBePlaced = false;
    }

    public void move(GameObject toMove, Image panel)
    {
        panel.gameObject.SetActive(false);
        toSub = false;
        canBePlaced = false;
        positionRoutine = StartCoroutine(changePositionTick(toMove));
        
    }
}
