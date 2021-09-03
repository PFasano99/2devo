using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class architectMenager : MonoBehaviour
{
    public int actualGoal;
    int flagGoal;

    public int timeToCraft = 0;

    public float copperBarInternal, woodInternal, woodPlankInternal, ironPlateInternal, stoneInternal, ironBarInternal, fiberInternal;
    public int[] allInternal;

    public int copperBarNeed, woodNeed, woodPankNeed, ironPlateNeed, ironWireNeed, stoneNeed, fiberNeed;
    

    public Text copperBarInit, woodInit, woodPlankInit, ironPlateInit, stoneInit, ironBarInit, fiberInit;
    public Text copperBarNeedT, woodNeedT, woodPlanksNeedT, ironPlateNeedT, stoneNeedT, ironBarNeedT, fiberNeedT;
    public Text[] allNeedeT;
    public GameObject[] architectInit;
    public Text[] allInit;

    public Image panelRetrive;

    public Slider sliderCraft;
    public Text maxCraftT;


    public Button craftB;
    public Text craftT;

    public Button depositB, shopB, sawmillB, blacksmithB, meccanicB, architectB, powerB;
    private Button[] allBuildingB;


    private string buildingType;
    //public GameObject deposit, shop, sawmill, blacksmith, meccanic, architect, power;
    private Vector3 actualPosition;

    private Coroutine craftRoutine = null;
    // Start is called before the first frame update
    void Start()
    {
        allNeedeT = new Text[] { copperBarNeedT, woodNeedT, woodPlanksNeedT, ironPlateNeedT, stoneNeedT, ironBarNeedT, fiberNeedT };
        allBuildingB = new Button[] { depositB, shopB, sawmillB, blacksmithB, meccanicB, architectB, powerB };
        architectInit = new GameObject[] {FindObjectOfType<allPrefab>().copperBar, FindObjectOfType<allPrefab>().wood, FindObjectOfType<allPrefab>().woodPlanks, FindObjectOfType<allPrefab>().ironPlate, FindObjectOfType<allPrefab>().stone, FindObjectOfType<allPrefab>().ironBar, FindObjectOfType<allPrefab>().fiber };
        actualPosition = transform.position;
        allInit = new Text[] { copperBarInit, woodInit, woodPlankInit, ironPlateInit, stoneInit, ironBarInit, fiberInit };


        panelRetrive.gameObject.SetActive(false);

        craftB.GetComponent<Button>();
        craftB.onClick.AddListener(delegate {
          craft(buildingType);         
        });

        depositB.GetComponent<Button>();
        depositB.onClick.AddListener(delegate {
            buildingType = "deposit";
            timeToCraft = 10;

            FindObjectOfType<craftingMenager>().resetButtonColor(depositB, craftT, sliderCraft, allBuildingB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

           checkMaxCraft(buildingType);
            
        });

        shopB.GetComponent<Button>();
        shopB.onClick.AddListener(delegate {
            buildingType = "shop";
            timeToCraft = 10;

            FindObjectOfType<craftingMenager>().resetButtonColor(shopB, craftT, sliderCraft, allBuildingB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            checkMaxCraft(buildingType);
        });

        sawmillB.GetComponent<Button>();
        sawmillB.onClick.AddListener(delegate {
            buildingType = "sawmill";
            timeToCraft = 10;

            FindObjectOfType<craftingMenager>().resetButtonColor(sawmillB, craftT, sliderCraft, allBuildingB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            checkMaxCraft(buildingType);
        });

        blacksmithB.GetComponent<Button>();
        blacksmithB.onClick.AddListener(delegate {
            buildingType = "blacksmith";
            timeToCraft = 10;

            FindObjectOfType<craftingMenager>().resetButtonColor(blacksmithB, craftT, sliderCraft, allBuildingB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            checkMaxCraft(buildingType);
        });

        meccanicB.GetComponent<Button>();
        meccanicB.onClick.AddListener(delegate {
            buildingType = "meccanic";
            timeToCraft = 10;

            FindObjectOfType<craftingMenager>().resetButtonColor(meccanicB, craftT, sliderCraft, allBuildingB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            checkMaxCraft(buildingType);

        });

        architectB.GetComponent<Button>();
        architectB.onClick.AddListener(delegate {
            buildingType = "architect";
            timeToCraft = 10;

            FindObjectOfType<craftingMenager>().resetButtonColor(architectB, craftT, sliderCraft, allBuildingB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            checkMaxCraft(buildingType);

        });

        powerB.GetComponent<Button>();
        powerB.onClick.AddListener(delegate {
            buildingType = "power";
            timeToCraft = 10;

            FindObjectOfType<craftingMenager>().resetButtonColor(powerB, craftT, sliderCraft, allBuildingB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);

            checkMaxCraft(buildingType);

        });

        sliderCraft.GetComponent<Slider>();
        sliderCraft.onValueChanged.AddListener(delegate {
                changeSlider(sliderCraft, sliderCraft.value, craftT, buildingType);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void craft(string type)
    {
        actualGoal = (int)sliderCraft.value;
        if (type.Equals("deposit") && woodInternal > 19)
        {           
            woodInternal -= actualGoal * 20;
            
        }
        else if (type.Equals("shop"))
        {
            woodInternal -= actualGoal * 20;
            stoneInternal -= actualGoal * 10;
        }
        else if (type.Equals("sawmill"))
        {
            woodInternal -= actualGoal * 30;
            stoneInternal -= actualGoal * 10;
        }
        else if (type.Equals("blacksmith"))
        {
            woodInternal -= actualGoal * 20;
            stoneInternal -= actualGoal * 10;
            woodPlankInternal -= actualGoal * 5;
        }
        else if (type.Equals("meccanic"))
        {
            woodInternal -= actualGoal * 20;
            stoneInternal -= actualGoal * 10;
            woodPlankInternal -= actualGoal * 15;
            ironBarInternal -= actualGoal * 5;
           
        }
        else if (type.Equals("architect"))
        {
            woodInternal -= actualGoal * 20;
            stoneInternal -= actualGoal * 10;
            woodPlankInternal -= actualGoal * 20;
        }
        else if (type.Equals("power"))
        {
            woodInternal -= actualGoal * 20;
            stoneInternal -= actualGoal * 10;
            woodPlankInternal -= actualGoal * 15;
            ironBarInternal -= actualGoal * 5;
            copperBarInternal -= actualGoal * 5;
        }

        craftRoutine = StartCoroutine(productionTimeTick(timeToCraft, type, 1));
        checkMaxCraft(type);
        FindObjectOfType<craftingMenager>().internalStorageDisplay(allInit, allInternal);
    }
    public void checkMaxCraft(string type)
    {
        int max = 0;
        if(type.Equals("deposit"))
        {
            max = (int) woodInternal / 20;
        }
        else if (type.Equals("shop"))
        {
            if (woodInternal / 20 < stoneInternal / 10)
                max = (int) woodInternal / 20;
            else
                max = (int) stoneInternal / 10;
        }
        else if (type.Equals("sawmill"))
        {
            if (woodInternal / 30 < stoneInternal / 10)
                max = (int) woodInternal / 30;
            else
                max = (int) stoneInternal / 10;
        }
        else if (type.Equals("blacksmith"))
        {
            if (woodInternal / 20 < stoneInternal / 10 && woodInternal / 20 < woodPlankInternal / 5)
                max = (int)woodInternal / 20;
            else if (stoneInternal / 10 < woodPlankInternal / 5)
                max = (int)stoneInternal / 10;
            else
                max = (int)woodPlankInternal / 5;
        }
        else if (type.Equals("meccanic"))
        {
            if (woodInternal / 20 < stoneInternal / 10 && woodInternal / 20 < woodPlankInternal / 15 && woodInternal / 20 < ironBarInternal / 5)
                max = (int)woodInternal / 20;
            else if (stoneInternal / 10 < woodPlankInternal / 15 && stoneInternal / 10 < ironBarInternal / 5)
                max = (int)stoneInternal / 10;
            else if (woodPlankInternal / 15 < ironBarInternal / 5)
                max = (int)woodPlankInternal / 15;
            else
                max = (int)ironBarInternal / 5; 
            
        }
        else if (type.Equals("architect"))
        {
            if (woodInternal / 20 < stoneInternal / 10 && woodInternal / 20 < woodPlankInternal / 20)
                max = (int)woodInternal / 20;
            else if (stoneInternal / 10 < woodPlankInternal / 20)
                max = (int)stoneInternal / 10;
            else
                max = (int)woodPlankInternal / 20;         
        }
        else if (type.Equals("power"))
        {
            if (woodInternal / 20 < stoneInternal / 10 && woodInternal / 20 < woodPlankInternal / 15 && woodInternal / 20 < ironBarInternal / 5 && woodInternal / 20 < copperBarInternal / 5)
                max = (int)woodInternal / 20;
            else if (stoneInternal / 10 < woodPlankInternal / 15 && stoneInternal / 10 < ironBarInternal / 5 && stoneInternal / 10 < copperBarInternal / 5)
                max = (int)stoneInternal / 10;
            else if (woodPlankInternal / 15 < ironBarInternal / 5 && woodPlankInternal / 15 < copperBarInternal / 5)
                max = (int)woodPlankInternal / 15;
            else if (ironBarInternal / 5 < copperBarInternal / 5)
                max = (int)ironBarInternal / 5;
            else
                max = (int)copperBarInternal / 5;
        }
        FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraftT);
    }

    public void changeSlider(Slider s, float value, Text display, string type)
    {
        flagGoal = (int)value;
        s.SetValueWithoutNotify(flagGoal);

        if (type == "deposit")
        {
            woodNeedT.text = "" + flagGoal * 20;
        }
        else if (type.Equals("shop"))
        {
            woodNeedT.text = "" + flagGoal * 20;
            stoneNeedT.text = "" + flagGoal * 10;
        }
        else if (type.Equals("sawmill"))
        {
            woodNeedT.text = "" + flagGoal * 30;
            stoneNeedT.text = "" + flagGoal * 10;
        }
        else if (type.Equals("blacksmith"))
        {
            woodNeedT.text = "" + flagGoal * 20;
            stoneNeedT.text = "" + flagGoal * 10;
            woodPlanksNeedT.text = "" + flagGoal * 5;
        }
        else if (type.Equals("meccanic"))
        {
            woodNeedT.text = "" + flagGoal * 20;
            stoneNeedT.text = "" + flagGoal * 10;
            woodPlanksNeedT.text = "" + flagGoal * 15;
            ironBarNeedT.text = "" + flagGoal * 5;
        }
        else if (type.Equals("architect"))
        {
            woodNeedT.text = "" + flagGoal * 20;
            stoneNeedT.text = "" + flagGoal * 10;
            woodPlanksNeedT.text = "" + flagGoal * 20;           
        }
        else if (type.Equals("power"))
        {
            woodNeedT.text = "" + flagGoal * 20;
            stoneNeedT.text = "" + flagGoal * 10;
            woodPlanksNeedT.text = "" + flagGoal * 15;
            ironBarNeedT.text = "" + flagGoal * 5;
            copperBarNeedT.text = "" + flagGoal * 5;
        }

        display.text = "Craft: " + flagGoal;
    }

    IEnumerator productionTimeTick(float second, string type, int madePerCraft)
    {
        while (true)
        {
            do
            {
                yield return new WaitForSeconds(second);
                actualCraft(buildingType, madePerCraft);
                actualGoal -= madePerCraft;
                FindObjectOfType<resourceQuantity>().setCurrentQuantity(FindObjectOfType<resourceQuantity>().getCurrentQuantity() + 1);

            } while (actualGoal > 0);
            StopCoroutine(craftRoutine);
        }
    }

    public void actualCraft(string type, int value)
    {
        //GameObject gameObject = (GameObject)Instantiate(toSpawn, deliveryPoint.position, Quaternion.identity);
        if(type.Equals("deposit"))
        {
            FindObjectOfType<resourceQuantity>().setDeposit(FindObjectOfType<resourceQuantity>().getDeposit() + value);
        }
        else if(type.Equals("shop"))
        {
            FindObjectOfType<resourceQuantity>().setShop(FindObjectOfType<resourceQuantity>().getShop() + value);
        }
        else if (type.Equals("sawmill"))
        {
            FindObjectOfType<resourceQuantity>().setSawmill(FindObjectOfType<resourceQuantity>().getSawmill() + value);
        }
        else if (type.Equals("blacksmith"))
        {
            FindObjectOfType<resourceQuantity>().setBlacksmith(FindObjectOfType<resourceQuantity>().getBlacksmith() + value);
        }
        else if (type.Equals("meccanic"))
        {
            FindObjectOfType<resourceQuantity>().setMeccanic(FindObjectOfType<resourceQuantity>().getMeccanic() + value);
        }
        else if (type.Equals("architect"))
        {
            FindObjectOfType<resourceQuantity>().setArchitect(FindObjectOfType<resourceQuantity>().getArchitect() + value);
        }
        else if (type.Equals("power"))
        {
            FindObjectOfType<resourceQuantity>().setPower(FindObjectOfType<resourceQuantity>().getPower() + value);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.tag == "rawResource" && FindObjectOfType<buildingMenager>().isPlaced)
            {
                GameObject resource = collision.gameObject;
                resourceMenager rm = resource.GetComponent<resourceMenager>();
                if (rm.resourceTypes == resourceMenager.ResourceTypes.Fiber)
                {
                    fiberInternal += rm.quantity;
                    Destroy(resource);
                }               
                else if (rm.resourceTypes == resourceMenager.ResourceTypes.IronPlate)
                {
                    ironPlateInternal += rm.quantity;
                    Destroy(resource);
                }
                else if (rm.resourceTypes == resourceMenager.ResourceTypes.Wood)
                {
                    woodInternal += rm.quantity;
                    Destroy(resource);
                }
                else if (rm.resourceTypes == resourceMenager.ResourceTypes.WoodPlanks)
                {
                    woodPlankInternal += rm.quantity;
                    Destroy(resource);
                }
                else if (rm.resourceTypes == resourceMenager.ResourceTypes.Stone)
                {
                    stoneInternal += rm.quantity;
                    Destroy(resource);
                }
                else if (rm.resourceTypes == resourceMenager.ResourceTypes.Iron)
                {
                    ironBarInternal += rm.quantity;
                    Destroy(resource);
                }
                else if (rm.resourceTypes == resourceMenager.ResourceTypes.Copper)
                {
                    copperBarInternal += rm.quantity;
                    Destroy(resource);
                }

                allInternal = new int[] { (int)copperBarInternal, (int)woodInternal, (int)woodPlankInternal, (int)ironPlateInternal, (int)stoneInternal, (int)ironBarInternal, (int)fiberInternal };
                FindObjectOfType<craftingMenager>().internalStorageDisplay(allInit, allInternal);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnDestroy()
    {
        allInternal = new int[] { (int)copperBarInternal, (int)woodInternal, (int)woodPlankInternal, (int)ironPlateInternal, (int)stoneInternal, (int)ironBarInternal, (int)fiberInternal };        
        FindObjectOfType<craftingMenager>().multipleCrafting(allInternal, architectInit, actualPosition);
    }
}
