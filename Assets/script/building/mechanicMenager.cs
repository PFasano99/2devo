using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mechanicMenager : MonoBehaviour
{
    public int actualGoal;
    int flagGoal;

    public int timeToCraft = 0;

    public float copperPlateInternal, copperWireInternal, copperGearInternal, ironPlateInternal, ironWireInternal, ironGearInternal, fiberInternal;
    public int copperPlateNeed, copperWireNeed, copperGearNeed, ironPlateNeed, ironWireNeed, ironGearNeed, fiberNeed;

    public Text copperPlateInit, copperWireInit, copperGearInit, ironPlateInit, ironWireInit, ironGearInit, fiberInit;
    private Text[] allInitT;
    private int[] allInternal;

    public Text copperPlateNeedT, copperWireNeedT, copperGearNeedT, ironPlateNeedT, ironWireNeedT, ironGearNeedT, fiberNeedT;
    public Text[] allNeedeT;

    public Slider sliderCraft;
    public Text maxCraftT;
    

    public Button craftB;
    public Text craftT;

    public Button copperWireB, copperGearB, ironWireB, ironGearB, convayorB;
    private Button[] allObjectsB;
    private GameObject[] allInitGo;

    public GameObject copperWire, copperGear, ironWire, ironGear, convayor;

    private resourceMenager ResourceMenager = new resourceMenager();
    private conveyorBeltManager ConveyorBeltManager = new conveyorBeltManager();

    private Coroutine craftRoutine = null;

    public Transform deliveryPoint;

    private bool isBelt;

    // Start is called before the first frame update
    void Start()
    {
       
        allNeedeT = new Text[] { copperPlateNeedT, copperWireNeedT, copperGearNeedT, ironPlateNeedT, ironWireNeedT, ironGearNeedT, fiberNeedT };
        allObjectsB = new Button[] { copperWireB, copperGearB, ironWireB, ironGearB, convayorB };
        allInitT = new Text[] { copperPlateInit, copperWireInit, copperGearInit, ironPlateInit, ironWireInit, ironGearInit, fiberInit };
        allInternal = new int[] { (int)copperPlateInternal, (int)copperWireInternal, (int)copperGearInternal, (int)ironPlateInternal, (int)ironWireInternal, (int)ironGearInternal, (int)fiberInternal };
        allInitGo = new GameObject[] { FindObjectOfType<allPrefab>().copperPlate, FindObjectOfType<allPrefab>().copperWire, FindObjectOfType<allPrefab>().copperGear, FindObjectOfType<allPrefab>().ironPlate, FindObjectOfType<allPrefab>().ironWire, FindObjectOfType<allPrefab>().ironGear, FindObjectOfType<allPrefab>().fiber};

        craftB.GetComponent<Button>();
        craftB.onClick.AddListener(delegate {
            if (!isBelt)
                craft(ResourceMenager);
            else
                craftBelt(ConveyorBeltManager);
        });

        copperWireB.GetComponent<Button>();       
        copperWireB.onClick.AddListener(delegate { 
            ResourceMenager.timeToProduce = 5; 
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperWire;

            FindObjectOfType<craftingMenager>().resetButtonColor(copperWireB, craftT, sliderCraft, allObjectsB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            FindObjectOfType<craftingMenager>().maxCraft(copperPlateInternal, sliderCraft, maxCraftT);
            isBelt = false;
        });

        copperGearB.GetComponent<Button>();
        copperGearB.onClick.AddListener(delegate { 
            ResourceMenager.timeToProduce = copperGear.GetComponent<resourceMenager>().timeToProduce;
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperGear;

            FindObjectOfType<craftingMenager>().resetButtonColor(copperGearB, craftT, sliderCraft,allObjectsB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            FindObjectOfType<craftingMenager>().maxCraft(copperPlateInternal, sliderCraft, maxCraftT);
            isBelt = false;
        });

        ironWireB.GetComponent<Button>();
        ironWireB.onClick.AddListener(delegate { 
            ResourceMenager.timeToProduce = ironWire.GetComponent<resourceMenager>().timeToProduce;
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronWire;

            FindObjectOfType<craftingMenager>().resetButtonColor(ironWireB, craftT, sliderCraft, allObjectsB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            FindObjectOfType<craftingMenager>().maxCraft(ironPlateInternal, sliderCraft, maxCraftT);
            isBelt = false;
        });

        ironGearB.GetComponent<Button>();
        ironGearB.onClick.AddListener(delegate { 
            ResourceMenager.timeToProduce = ironGear.GetComponent<resourceMenager>().timeToProduce; 
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronGear;

            FindObjectOfType<craftingMenager>().resetButtonColor(ironGearB, craftT, sliderCraft, allObjectsB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            FindObjectOfType<craftingMenager>().maxCraft(ironPlateInternal, sliderCraft, maxCraftT);
            isBelt = false;
        });

         convayorB.GetComponent<Button>();
         convayorB.onClick.AddListener(delegate {
             ConveyorBeltManager.timeToProduce = convayor.GetComponent<conveyorBeltManager>().timeToProduce;
             ConveyorBeltManager.beltTypes = conveyorBeltManager.BeltTypes.noFilter;

             FindObjectOfType<craftingMenager>().resetButtonColor(convayorB, craftT, sliderCraft, allObjectsB);
             FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

             maxCraftByBelt(ConveyorBeltManager);
             isBelt = true;
         });
      

        sliderCraft.GetComponent<Slider>();
        sliderCraft.onValueChanged.AddListener(delegate {
            if(isBelt)
             changeSliderBelt(sliderCraft, sliderCraft.value, craftT, ConveyorBeltManager);
            else
             changeSlider(sliderCraft, sliderCraft.value, craftT, ResourceMenager); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSliderBelt(Slider s, float value, Text display, conveyorBeltManager menager)
    {
        flagGoal = (int)value;
        s.SetValueWithoutNotify(flagGoal);

        if (menager.beltTypes.Equals(conveyorBeltManager.BeltTypes.noFilter))
        {
            display.text = "Craft: " + flagGoal;
            fiberNeedT.text = "" + flagGoal * 4;
            ironGearNeedT.text = "" + flagGoal * 3;
            copperWireNeedT.text = "" + flagGoal*2;
            copperGearNeedT.text = "" + flagGoal;
        }      

    }

    public void changeSlider(Slider s, float value, Text display, resourceMenager rm)
    {
        flagGoal = (int)value;
        s.SetValueWithoutNotify(flagGoal);
        
        if (rm.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperGear))
        {
            display.text = "Craft: " + flagGoal+" x 2";
            copperPlateNeedT.text = "" + flagGoal;
        }
        else if (rm.resourceTypes.Equals(resourceMenager.ResourceTypes.IronGear))
        {
            display.text = "Craft: " + flagGoal + " x 2";
            ironPlateNeedT.text = "" + flagGoal;
        }
        else if (rm.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperWire))
        {
            display.text = "Craft: " + flagGoal + "x2";
            copperPlateNeedT.text = "" + flagGoal;
        }
        else if (rm.resourceTypes.Equals(resourceMenager.ResourceTypes.IronWire))
        {
            display.text = "Craft: " + flagGoal + "x2";
            ironPlateNeedT.text = "" + flagGoal;
        }

    }

    public void maxCraftByBelt(conveyorBeltManager menager)
    {
        int maxFlag = 0;
        if(menager.beltTypes.Equals(conveyorBeltManager.BeltTypes.noFilter))
        {
            if (fiberInternal / 4 <= ironGearInternal / 3 && fiberInternal / 4 <= copperWireInternal && fiberInternal / 4 <= copperGearInternal)
                maxFlag = (int)fiberInternal / 4;

            else if (ironGearInternal / 3 <= copperWireInternal / 2 && ironGearInternal / 3 <= copperGearInternal)
                maxFlag = (int)ironGearInternal / 3;

            else if (copperWireInternal / 2 <= copperGearInternal)
                maxFlag = (int)copperWireInternal / 2;

            else
                maxFlag = (int)copperGearInternal;
        }

        FindObjectOfType<craftingMenager>().maxCraft(maxFlag, sliderCraft, maxCraftT);
    }
    
    public void craftBelt(conveyorBeltManager menager)
    {
        if (menager.beltTypes.Equals(conveyorBeltManager.BeltTypes.noFilter) && fiberInternal >= 4 && ironGearInternal >= 3 && copperWireInternal >= 2 && copperGearInternal >= 1)
        {
            actualGoal = (int)sliderCraft.value;
            fiberInternal -= actualGoal * 4;
            ironGearInternal -= actualGoal * 3;
            copperWireInternal -= actualGoal * 2;
            copperGearInternal -= actualGoal;

            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, convayor, 1));
        }

        allInternal = new int[] { (int)copperPlateInternal, (int)copperWireInternal, (int)copperGearInternal, (int)ironPlateInternal, (int)ironWireInternal, (int)ironGearInternal, (int)fiberInternal };

        FindObjectOfType<craftingMenager>().internalStorageDisplay(allInitT, allInternal);
        maxCraftByBelt(menager);
    }
    public void craft(resourceMenager menager)
    {
        Debug.Log("4 here " + menager.resourceTypes);
        if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronGear) && ironPlateInternal > 0)
        {
            actualGoal = (int)sliderCraft.value;
            ironPlateInternal -= actualGoal;
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, ironGear, 2));
            FindObjectOfType<craftingMenager>().maxCraft(ironPlateInternal, sliderCraft, maxCraftT);
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperGear) && copperPlateInternal > 0)
        {
            actualGoal = (int)sliderCraft.value;
            copperPlateInternal -= actualGoal;
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, copperGear, 2));
            FindObjectOfType<craftingMenager>().maxCraft(copperPlateInternal, sliderCraft, maxCraftT);
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronWire) && ironPlateInternal > 0)
        {
            actualGoal = (int)sliderCraft.value;
            ironPlateInternal -= actualGoal;
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, ironWire, 4));
            FindObjectOfType<craftingMenager>().maxCraft(ironPlateInternal, sliderCraft, maxCraftT);
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperWire) && copperPlateInternal > 0)
        {
            actualGoal = (int)sliderCraft.value;
            copperPlateInternal -= actualGoal;
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, copperWire, 4));
            FindObjectOfType<craftingMenager>().maxCraft(copperPlateInternal, sliderCraft, maxCraftT);
        }

        allInternal = new int[] { (int)copperPlateInternal, (int)copperWireInternal, (int)copperGearInternal, (int)ironPlateInternal, (int)ironWireInternal, (int)ironGearInternal, (int)fiberInternal };
        FindObjectOfType<craftingMenager>().internalStorageDisplay(allInitT, allInternal);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Debug.Log(collision.gameObject.tag + " "+ FindObjectOfType<buildingMenager>().isPlaced);
            Debug.Log("here 1");
            if (collision.gameObject.tag == "rawResource" && FindObjectOfType<buildingMenager>().isPlaced)
            {
                GameObject resource = collision.gameObject;
                Debug.Log(collision.gameObject.ToString());
                resourceMenager rm = resource.GetComponent<resourceMenager>();
                if (rm.resourceTypes == resourceMenager.ResourceTypes.Fiber)
                {
                    fiberInternal += rm.quantity;
                    Destroy(resource);
                }
                if (rm.resourceTypes == resourceMenager.ResourceTypes.IronWire)
                {
                    ironWireInternal += rm.quantity;
                    Destroy(resource);
                }
                if (rm.resourceTypes == resourceMenager.ResourceTypes.CopperWire)
                {
                    copperWireInternal += rm.quantity;
                    Destroy(resource);
                }
                if (rm.resourceTypes == resourceMenager.ResourceTypes.CopperPlate)
                {
                    copperPlateInternal += rm.quantity;
                    Destroy(resource);
                }
                if (rm.resourceTypes == resourceMenager.ResourceTypes.IronPlate)
                {
                    ironPlateInternal += rm.quantity;
                    Destroy(resource);
                }
                if (rm.resourceTypes == resourceMenager.ResourceTypes.CopperGear)
                {
                    copperGearInternal += rm.quantity;
                    Destroy(resource);
                }
                if (rm.resourceTypes == resourceMenager.ResourceTypes.IronGear)
                {
                    ironGearInternal += rm.quantity;
                    Destroy(resource);
                }
                allInternal = new int[] { (int)copperPlateInternal, (int)copperWireInternal, (int)copperGearInternal, (int)ironPlateInternal, (int)ironWireInternal, (int)ironGearInternal, (int)fiberInternal };
                FindObjectOfType<craftingMenager>().internalStorageDisplay(allInitT, allInternal);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnDestroy()
    {
        allInternal = new int[] { (int)copperPlateInternal, (int)copperWireInternal, (int)copperGearInternal, (int)ironPlateInternal, (int)ironWireInternal, (int)ironGearInternal, (int)fiberInternal };
        FindObjectOfType<craftingMenager>().multipleCrafting(allInternal, allInitGo, deliveryPoint.position);
    }
}
