using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blacksmithMenager : MonoBehaviour
{
    public int coalInternal, ironOreInternal, copperOreInternal, ironBarInternal, copperBarInternal;
    public int[] allInternal;
    public GameObject[] allInternalGo;
    public int coalNeed, ironNeed, copperNeed, ironBarNeed, copperBarNeed;
    public int[] allNeed; 

    public int actualGoal;
    int flagGoal;
    
    public int timeToCraft = 0;

    public Transform deliveryPoint;

    public Button craftB;
    public Text craftT;

    public Text maxCraftT;

    public Button ironBarB, copperBarB, ironPlateB, copperPlateB;
    public Button[] allCraftableB;
    
    public Slider sliderCraft;  

    public Text coalInit, ironOreInit, copperOreInit, ironBarInit, copperBarInit;
    public Text[] allInternalT;
    public Text coalNeedT, ironNeedT, copperNeedT, ironBarNeedT, copperBarNeedT;
    public Text[] allNeedT;

    private resourceMenager ResourceMenager = new resourceMenager();

    private Coroutine craftRoutine = null;

    // Start is called before the first frame update
    void Start()
    {
        allCraftableB = new Button[] { ironBarB, copperBarB, ironPlateB, copperPlateB };
        allNeedT = new Text[] { coalNeedT, ironNeedT, copperNeedT, ironBarNeedT, copperBarNeedT };
        allNeed = new int[] { coalNeed, ironNeed, copperNeed, ironBarNeed, copperBarNeed };
        allInternal = new int[] { coalInternal, ironOreInternal, copperOreInternal, ironBarInternal, copperBarInternal };
        allInternalGo = new GameObject[] { FindObjectOfType<allPrefab>().coal, FindObjectOfType<allPrefab>().ironOre, FindObjectOfType<allPrefab>().copperOre, FindObjectOfType<allPrefab>().ironBar, FindObjectOfType<allPrefab>().copperBar };
        allInternalT = new Text[] { coalInit, ironOreInit, copperOreInit, ironBarInit, copperBarInit };

        ironBarB.GetComponent<Button>();
        ResourceMenager.timeToProduce = 5;
        ironBarB.onClick.AddListener(delegate { 
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Iron; 
            craft(ResourceMenager);
            FindObjectOfType<craftingMenager>().resetButtonColor(ironBarB, craftT, sliderCraft, allCraftableB);
            checkMaxCraft(ResourceMenager);
        });
        

        copperBarB.GetComponent<Button>();
        ResourceMenager.timeToProduce = 5;       
        copperBarB.onClick.AddListener(delegate { 
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Copper; 
            craft(ResourceMenager);
            FindObjectOfType<craftingMenager>().resetButtonColor(copperBarB, craftT, sliderCraft, allCraftableB);
            checkMaxCraft(ResourceMenager);
        });

        copperPlateB.GetComponent<Button>();
        ResourceMenager.timeToProduce = 5;      
        copperPlateB.onClick.AddListener(delegate { 
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperPlate; 
            craft(ResourceMenager);
            FindObjectOfType<craftingMenager>().resetButtonColor(copperPlateB, craftT, sliderCraft, allCraftableB);
            checkMaxCraft(ResourceMenager);
        });

        ironPlateB.GetComponent<Button>();        
        ResourceMenager.timeToProduce = 5;       
        ironPlateB.onClick.AddListener(delegate { 
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronPlate; 
            craft(ResourceMenager);
            FindObjectOfType<craftingMenager>().resetButtonColor(ironPlateB, craftT, sliderCraft, allCraftableB);
            checkMaxCraft(ResourceMenager);
        });

        craftB.GetComponent<Button>();
        craftB.onClick.AddListener(delegate {
            craft(ResourceMenager);
            checkMaxCraft(ResourceMenager);
         });

        sliderCraft.GetComponent<Slider>();
        sliderCraft.onValueChanged.AddListener(delegate {
            changeSlider(sliderCraft, sliderCraft.value, craftT, ResourceMenager);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSlider(Slider s, float value, Text display, resourceMenager menager)
    {
        flagGoal = (int)value;
        s.SetValueWithoutNotify(flagGoal);
        display.text = "" + flagGoal;
        if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Iron))
        {
            coalNeedT.text = flagGoal.ToString();
            ironNeedT.text = flagGoal.ToString();
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Copper))
        {
            coalNeedT.text = flagGoal.ToString();
            copperNeedT.text = flagGoal.ToString();
        }
        else if(menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperPlate))
        {
            coalNeedT.text = flagGoal.ToString();
            copperBarNeedT.text = flagGoal.ToString();
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronPlate))
        {
            coalNeedT.text = flagGoal.ToString();
            ironBarNeedT.text = flagGoal.ToString();
        }
    }
    public void checkMaxCraft(resourceMenager menager)
    {
        int flag = 0;
        if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Iron))
        {
            if (coalInternal < ironOreInternal)
                flag = coalInternal;
            else
                flag = ironOreInternal; coalNeedT.text = flagGoal.ToString();
            ironNeedT.text = flagGoal.ToString();
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Copper))
        {
            if (coalInternal < copperOreInternal)
                flag = coalInternal;
            else
                flag = copperOreInternal;
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperPlate))
        {
            if (coalInternal < copperBarInternal)
                flag = coalInternal;
            else
                flag = copperBarInternal;
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronPlate))
        {
            if (coalInternal < ironBarInternal)
                flag = coalInternal;
            else
                flag = ironBarInternal;
        }
        
        FindObjectOfType<craftingMenager>().maxCraft(flag, sliderCraft, maxCraftT);
    }
  

    IEnumerator productionTimeTick(float second, GameObject gameObject, int madePerCraft)
    {
        while (true)
        {
            do
            {
                yield return new WaitForSeconds(second);
                FindObjectOfType<craftingMenager>().actualCraft(gameObject, deliveryPoint.position);
                actualGoal -= madePerCraft;
            } while (actualGoal > 0);
            StopCoroutine(craftRoutine);
        }
    }


    public void craft(resourceMenager menager)
    {
       
        if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Iron)  && ironOreInternal > 0 && coalInternal > 0)
        {
            actualGoal = (int)sliderCraft.value;
            ironOreInternal -= actualGoal;
            coalInternal -= actualGoal;
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, FindObjectOfType<allPrefab>().ironBar, 1));
        }
        else if(menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Copper) && copperOreInternal > 0 && coalInternal > 0)
        {
            actualGoal = (int)sliderCraft.value;
            copperOreInternal -= actualGoal;
            coalInternal -= actualGoal;
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, FindObjectOfType<allPrefab>().copperBar, 1));
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperPlate) && copperBarInternal > 0 && coalInternal > 0)
        {
            actualGoal = (int)sliderCraft.value;
            copperBarInternal -= actualGoal;
            coalInternal -= actualGoal;
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, FindObjectOfType<allPrefab>().copperPlate, 2));
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronPlate) && ironBarInternal > 0 && coalInternal > 0)
        {
            actualGoal = (int)sliderCraft.value;
            ironBarInternal -= actualGoal;
            coalInternal -= actualGoal;
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, FindObjectOfType<allPrefab>().ironPlate, 2));
        }

        allInternal = new int[] { coalInternal, ironOreInternal, copperOreInternal, ironBarInternal, copperBarInternal };
        FindObjectOfType<craftingMenager>().internalStorageDisplay(allInternalT, allInternal);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.tag == "rawResource" && FindObjectOfType<buildingMenager>().isPlaced)
            {
                GameObject resource = collision.gameObject;
                resourceMenager rm = resource.GetComponent<resourceMenager>();
                if (rm.resourceTypes == resourceMenager.ResourceTypes.Coal)
                {
                    coalInternal += rm.quantity;
                    Destroy(resource);
                }
                if(rm.resourceTypes == resourceMenager.ResourceTypes.IronOre)
                {
                    ironOreInternal += rm.quantity;
                    Destroy(resource);
                }
                if(rm.resourceTypes == resourceMenager.ResourceTypes.CopperOre)
                {
                    copperOreInternal += rm.quantity;
                    Destroy(resource);
                }
                if (rm.resourceTypes == resourceMenager.ResourceTypes.Copper)
                {
                    copperBarInternal += rm.quantity;
                    Destroy(resource);
                }
                if (rm.resourceTypes == resourceMenager.ResourceTypes.Iron)
                {
                    ironBarInternal += rm.quantity;
                    Destroy(resource);
                }
                allInternal = new int[] { coalInternal, ironOreInternal, copperOreInternal, ironBarInternal, copperBarInternal };
                FindObjectOfType<craftingMenager>().internalStorageDisplay(allInternalT, allInternal);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnDestroy()
    {
        allInternal = new int[] { coalInternal, ironOreInternal, copperOreInternal, ironBarInternal, copperBarInternal };
        FindObjectOfType<craftingMenager>().multipleCrafting(allInternal, allInternalGo, deliveryPoint.position);
    }
}
