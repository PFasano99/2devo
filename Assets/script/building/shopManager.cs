using System;
using UnityEngine;
using UnityEngine.UI;

public class shopManager : MonoBehaviour
{
    const float change = 2.25f;

    private resourceMenager ResourceMenager;

    public Transform deliveryPoint;

    public Button craftB;
    public Text craftT, maxCraft, costT;
    public Slider sliderCraft;

    public Button woodB, stoneB, coalB, ironOreB, copperOreB, woodPlankB, foodB, fiberB, ironB, copperB, ironGearB, copperGearB, ironPlateB, copperPlateB, ironWireB, copperWireB;
    private Button[] allB;

    // Start is called before the first frame update
    void Start()
    {
        allB = new Button[] { woodB, stoneB, coalB, ironOreB, copperOreB, woodPlankB, foodB, fiberB, ironB, copperB, ironGearB, copperGearB, ironPlateB, copperPlateB, ironWireB, copperWireB };
        ResourceMenager = new resourceMenager();
        //Button
        woodB.GetComponent<Button>();
        woodB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Wood;
            ResourceMenager.value = 2;
            costT.text = "COST: " + (int) (ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(woodB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });


        stoneB.GetComponent<Button>();
        stoneB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Stone;
            ResourceMenager.value = 3;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(stoneB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        coalB.GetComponent<Button>();
        coalB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Coal;
            ResourceMenager.value = 3;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(coalB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironOreB.GetComponent<Button>();
        ironOreB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronOre;
            ResourceMenager.value = 5;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(ironOreB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironB.GetComponent<Button>();
        ironB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Iron;
            ResourceMenager.value = 15;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(ironB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        copperB.GetComponent<Button>();
        copperB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Copper;
            ResourceMenager.value = 15;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(copperB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        copperOreB.GetComponent<Button>();
        copperOreB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperOre;
            ResourceMenager.value = 5;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(copperOreB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        woodPlankB.GetComponent<Button>();
        woodPlankB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.WoodPlanks;
            ResourceMenager.value = 8;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(woodPlankB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        fiberB.GetComponent<Button>();
        fiberB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Fiber;
            ResourceMenager.value = 1;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(fiberB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        foodB.GetComponent<Button>();
        foodB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Food;
            ResourceMenager.value = 2;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(foodB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        /*
         atomicB.GetComponent<Button>();
        ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Radioactive;
        atomicB.onClick.AddListener(delegate { createResource(ResourceMenager, atomicS.value); });
         */

        copperGearB.GetComponent<Button>();
        copperGearB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperGear;
            ResourceMenager.value = 20;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(copperGearB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironGearB.GetComponent<Button>();
        ironGearB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronGear;
            ResourceMenager.value = 22;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(ironGearB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        copperPlateB.GetComponent<Button>();
        copperPlateB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperPlate;
            ResourceMenager.value = 17;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(copperPlateB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironPlateB.GetComponent<Button>();
        ironPlateB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronPlate;
            ResourceMenager.value = 17;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(ironPlateB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        copperWireB.GetComponent<Button>();
        copperWireB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperWire;
            ResourceMenager.value = 11;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(copperWireB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironWireB.GetComponent<Button>();
        ironWireB.onClick.AddListener(delegate
        {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronWire;
            ResourceMenager.value = 12;
            costT.text = "COST: " + (int)(ResourceMenager.value * change);
            FindObjectOfType<craftingMenager>().resetButtonColor(ironWireB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        sliderCraft.GetComponent<Slider>();
        sliderCraft.onValueChanged.AddListener(delegate 
        {
            if(FindObjectOfType<resourceQuantity>().getCoins()>0)
            changeSlider(sliderCraft.value, craftT, ResourceMenager.value, costT); 
        });

        craftB.GetComponent<Button>();
        craftB.onClick.AddListener(delegate { createResource(ResourceMenager, sliderCraft.value, ResourceMenager.value); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createResource(resourceMenager menager, float value, float cost)
    {
        if (value > 0)
        {
            if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Wood))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().wood, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Stone))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().stone, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Coal))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().coal, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronOre))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironOre, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Iron))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironBar, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperOre))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperOre, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Copper))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperBar, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Fiber))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().fiber, deliveryPoint.position);
            }

            
             else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Food))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().food, deliveryPoint.position);

            }
            /*
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Radioactive) && FindObjectOfType<resourceQuantity>().getNuclear() != 0)
            {
                FindObjectOfType<resourceQuantity>().setNuclear(FindObjectOfType<resourceQuantity>().getNuclear() - (int)value);
                instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().atomic);
            }
             */


            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.WoodPlanks))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().woodPlanks, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperGear))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperGear, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronGear))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironGear, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperPlate))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperPlate, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronPlate))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironPlate, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperWire))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperWire, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronWire))
            {
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironWire, deliveryPoint.position);
            }

            Debug.Log("costo "+ value*  cost * change);
            FindObjectOfType<resourceQuantity>().setCoin(FindObjectOfType<resourceQuantity>().getCoins() - (int)(value * cost * change));
            maxRetrive(ResourceMenager);
        }
    }

    public void changeSlider(float value, Text quantity, float cost, Text costT)
    {
        int flag = (int)value;
        quantity.text = "BUY: " + flag;
        costT.text = "COST: " + (int)cost * value * change; 
    }


    public void maxRetrive(resourceMenager menager)
    {
        int max = 0;
        int flag = FindObjectOfType<resourceQuantity>().getCoins();
        
        if(flag > 0)
        {
            
            max = (int) (flag / (menager.value * change));
            Debug.Log("max craft " + max);
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);
            sliderCraft.maxValue = (float)max;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        try
        {
            if ((collision.gameObject.tag == "rawResource" || collision.gameObject.tag == "rawBelt") && FindObjectOfType<buildingMenager>().isPlaced)
            {
                GameObject resorce = collision.gameObject;
                ResourceMenager = resorce.GetComponent<resourceMenager>();
                ResourceMenager.sell();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }


}
