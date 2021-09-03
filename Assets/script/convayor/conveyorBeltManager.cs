using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorBeltManager : MonoBehaviour
{
    public enum BeltTypes { noFilter, rightFilter, leftFilter, bottomLeftFilter, bottomRightFilter, threeWayFilter, twoWayRightFilter, twoWayLeftFilter, twoWayFilter, cargoBay, splitter1, splitter2, splitter3 };
    public BeltTypes beltTypes;

    public Transform deliveryPoint;
    private int speed;

    public int status;
    public int quantity = 1;
    public int value = 1;
    public int timeToProduce = 0;

    private resourceMenager ResourceMenager = new resourceMenager();

    private Coroutine movingRoutine = null;
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
            if (collision.gameObject.tag == "rawResource" || collision.gameObject.tag == "rawBelt")
            {
                GameObject resorce = collision.gameObject;
                ResourceMenager = resorce.GetComponent<resourceMenager>();
                movingRoutine = StartCoroutine(moveOnBelt());
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ResourceMenager == null)
            StopAllCoroutines();
    }

    public void rotateBelt()
    {
        Vector3 rotationAmmount = new Vector3(0,0,90);
        gameObject.transform.Rotate(0,0,90,Space.Self);

        status++;
        if (status > 3)
        {          
            status = 0;
        }
    }

    IEnumerator moveOnBelt()
    {
        while (true)
        {       
            bool goOn = true;
            do
            {
                Debug.Log("Resource menager "+ResourceMenager.ToString());
                if (ResourceMenager == null)
                {
                    goOn = false;
                }
                else
                {
                    goOn = actualMovement();
                    yield return new WaitForSeconds(0.2f);
                }           
            } while (goOn);

            yield return new WaitForSeconds(0.0f);
            StopCoroutine(movingRoutine);
        }
    }

    public bool actualMovement()
    {
        Vector3 flagPoint = new Vector3();
               
        if (status == 0)
        {
            flagPoint = new Vector3(0.0f, -0.2f, 0);
            ResourceMenager.transform.position = new Vector3(deliveryPoint.position.x, ResourceMenager.transform.position.y, ResourceMenager.transform.position.y * 0.1f);
        }
        if (status == 1)
        {
            flagPoint = new Vector3(0.2f, 0, 0);
            ResourceMenager.transform.position = new Vector3(ResourceMenager.transform.position.x, deliveryPoint.position.y, ResourceMenager.transform.position.z * 0.1f);
        }
        if (status == 2)
        {
            flagPoint = new Vector3(0.0f, 0.2f, 0);
            ResourceMenager.transform.position = new Vector3(deliveryPoint.position.x, ResourceMenager.transform.position.y, ResourceMenager.transform.position.z * 0.1f);
        }
        if (status == 3)
        {           
            flagPoint = new Vector3(-0.2f, 0, 0);
            ResourceMenager.transform.position = new Vector3(ResourceMenager.transform.position.x, deliveryPoint.position.y, ResourceMenager.transform.position.z * 0.1f);
        }
        
    //Debug.Log("ResourceMenager.transform.position.y: " + ResourceMenager.transform.position.y + "deliveryPoint.position.y " + deliveryPoint.position.y);
    //Debug.Log("ResourceMenager.transform.position.x: " + ResourceMenager.transform.position.x + "deliveryPoint.position.x " + deliveryPoint.position.x);

        if (status == 0 && ResourceMenager.transform.position.y <= deliveryPoint.position.y)
        {
            return false;
        }
        if (status == 1 && ResourceMenager.transform.position.x >= deliveryPoint.position.x)
        {
            return false;
        }
        if (status == 2 && ResourceMenager.transform.position.y >= deliveryPoint.position.y)
        {
            return false;
        }
        if (status == 3 && ResourceMenager.transform.position.x <= deliveryPoint.position.x)
        {
            return false;
        }
        else
        {
            ResourceMenager.transform.position += flagPoint;
            return true;
        }
            
    }

   public void deposit(storageMenager storage)
    {
        int maxFlag = FindObjectOfType<resourceQuantity>().getCurrentQuantity() + quantity;
        if (maxFlag < FindObjectOfType<resourceQuantity>().getMaxSpace())
        {
            FindObjectOfType<resourceQuantity>().setCurrentQuantity(maxFlag);
            if (beltTypes.Equals(BeltTypes.noFilter))
                FindObjectOfType<resourceQuantity>().setNoFilter(FindObjectOfType<resourceQuantity>().getNoFilter() + quantity);

            Destroy(gameObject);
        }
        else
        {
            storage.noSpace();
        }
    }
}
