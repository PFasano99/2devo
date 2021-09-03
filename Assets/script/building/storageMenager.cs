using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storageMenager : MonoBehaviour
{
    private resourceMenager ResourceMenager = new resourceMenager();
    private conveyorBeltManager ConveyorBeltManager = new conveyorBeltManager();
    private storageMenager sMenager;

    public int storageSpace = 0;
    

    public Transform deliveryPoint;

    public Image panelSpace;

    public Button craftB;
    public Text craftT, maxCraft;
    public Slider sliderCraft;

    public Button woodB, stoneB, coalB, ironOreB, copperOreB, woodPlankB, foodB, fiberB, ironB, copperB, ironGearB, copperGearB, ironPlateB, copperPlateB, ironWireB, copperWireB;
    private Button[] allB;

    // Start is called before the first frame update
    void Start()
    {
        allB = new Button[] { woodB, stoneB, coalB, ironOreB, copperOreB, woodPlankB, foodB, fiberB, ironB, copperB, ironGearB, copperGearB, ironPlateB, copperPlateB, ironWireB, copperWireB };   
        sMenager = GetComponent<storageMenager>();

        FindObjectOfType<resourceQuantity>().setMaxSpace(FindObjectOfType<resourceQuantity>().getMaxSpace() + storageSpace);

        panelSpace.GetComponent<Image>();
        panelSpace.gameObject.SetActive(false);
        
        //Button
        woodB.GetComponent<Button>();        
        woodB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Wood; 
            FindObjectOfType<craftingMenager>().resetButtonColor(woodB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });
    

        stoneB.GetComponent<Button>();       
        stoneB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Stone; 
            FindObjectOfType<craftingMenager>().resetButtonColor(stoneB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        coalB.GetComponent<Button>();       
        coalB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Coal; 
            FindObjectOfType<craftingMenager>().resetButtonColor(coalB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironOreB.GetComponent<Button>();       
        ironOreB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronOre; 
            FindObjectOfType<craftingMenager>().resetButtonColor(ironOreB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironB.GetComponent<Button>();        
        ironB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Iron; 
            FindObjectOfType<craftingMenager>().resetButtonColor(ironB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        copperB.GetComponent<Button>();        
        copperB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Copper; 
            FindObjectOfType<craftingMenager>().resetButtonColor(copperB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });
        
        copperOreB.GetComponent<Button>();        
        copperOreB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperOre; 
            FindObjectOfType<craftingMenager>().resetButtonColor(copperOreB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        woodPlankB.GetComponent<Button>();       
        woodPlankB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.WoodPlanks; 
            FindObjectOfType<craftingMenager>().resetButtonColor(woodPlankB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        fiberB.GetComponent<Button>();       
        fiberB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Fiber; 
            FindObjectOfType<craftingMenager>().resetButtonColor(fiberB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        foodB.GetComponent<Button>();       
        foodB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Food; 
            FindObjectOfType<craftingMenager>().resetButtonColor(foodB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        /*
         atomicB.GetComponent<Button>();
        ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.Radioactive;
        atomicB.onClick.AddListener(delegate { createResource(ResourceMenager, atomicS.value); });
         */

        copperGearB.GetComponent<Button>();
        copperGearB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperGear; 
            FindObjectOfType<craftingMenager>().resetButtonColor(copperGearB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironGearB.GetComponent<Button>();
        ironGearB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronGear; 
            FindObjectOfType<craftingMenager>().resetButtonColor(ironGearB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        copperPlateB.GetComponent<Button>();
        copperPlateB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperPlate; 
            FindObjectOfType<craftingMenager>().resetButtonColor(copperPlateB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironPlateB.GetComponent<Button>();
        ironPlateB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronPlate; 
            FindObjectOfType<craftingMenager>().resetButtonColor(ironPlateB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        copperWireB.GetComponent<Button>();
        copperWireB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.CopperWire; 
            FindObjectOfType<craftingMenager>().resetButtonColor(copperWireB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        ironWireB.GetComponent<Button>();
        ironWireB.onClick.AddListener(delegate { ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.IronWire; 
            FindObjectOfType<craftingMenager>().resetButtonColor(ironWireB, craftT, sliderCraft, allB);
            maxRetrive(ResourceMenager);
        });

        sliderCraft.GetComponent<Slider>();
        sliderCraft.onValueChanged.AddListener(delegate { changeSlider(sliderCraft.value, craftT); }) ;

        craftB.GetComponent<Button>();
        craftB.onClick.AddListener(delegate { createResource(ResourceMenager, sliderCraft.value); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator noSpaceTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            panelSpace.gameObject.SetActive(false);
            StopCoroutine(noSpaceTick());
        }
        
    }

    public void noSpace()
    {
        panelSpace.gameObject.SetActive(true);
        StartCoroutine(noSpaceTick());
        noSpaceTick();
        
    }

    public void maxRetrive(resourceMenager menager)
    {
        int max = 0;
        if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Wood))
        {
            max = FindObjectOfType<resourceQuantity>().getWood();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);           
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Stone))
        {
            max = FindObjectOfType<resourceQuantity>().getStone();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);            
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Coal) )
        {
            max = FindObjectOfType<resourceQuantity>().getCoal();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);           
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronOre) )
        {
            max = FindObjectOfType<resourceQuantity>().getIronOre();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);           
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Iron))
        {
            max = FindObjectOfType<resourceQuantity>().getIron();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);          
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperOre) )
        {
            max = FindObjectOfType<resourceQuantity>().getCopperOre();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);          
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Copper) )
        {
            max = FindObjectOfType<resourceQuantity>().getCopper();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);           
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Fiber) )
        {
            max = FindObjectOfType<resourceQuantity>().getFiber();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);           
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.WoodPlanks) )
        {
            max = FindObjectOfType<resourceQuantity>().getWoodPlank();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);          
        }

        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperGear) )
        {
            max = FindObjectOfType<resourceQuantity>().getCopperGear();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);          
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronGear))
        {
            max = FindObjectOfType<resourceQuantity>().getIronGear();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);           
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperPlate))
        {
            max = FindObjectOfType<resourceQuantity>().getCopperPlate();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);           
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronPlate) )
        {
            max = FindObjectOfType<resourceQuantity>().getIronPlate();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);          
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperWire))
        {
            max = FindObjectOfType<resourceQuantity>().getCopperWire();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);          
        }
        else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronWire) )
        {
            max = FindObjectOfType<resourceQuantity>().getIronWire();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);         
        }
        else if(menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Food))
        {
            max = FindObjectOfType<resourceQuantity>().getFood();
            FindObjectOfType<craftingMenager>().maxCraft(max, sliderCraft, maxCraft);         
        }

        sliderCraft.maxValue = (float)max;
    }

    public void changeSlider(float value, Text display)
    {
        int flag = (int)value;
        display.text = "" + flag;
    }

    public void createResource(resourceMenager menager, float value)
    {
        
        if (value > 0)
        {         
            if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Wood) && FindObjectOfType<resourceQuantity>().getWood() != 0)
            {
                FindObjectOfType<resourceQuantity>().setWood(FindObjectOfType<resourceQuantity>().getWood() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().wood, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Stone) && FindObjectOfType<resourceQuantity>().getStone() != 0)
            {
                FindObjectOfType<resourceQuantity>().setStone(FindObjectOfType<resourceQuantity>().getStone() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().stone, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Coal) && FindObjectOfType<resourceQuantity>().getCoal() != 0)
            {
                FindObjectOfType<resourceQuantity>().setCoal(FindObjectOfType<resourceQuantity>().getCoal() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().coal, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronOre) && FindObjectOfType<resourceQuantity>().getIronOre() != 0)
            {
                FindObjectOfType<resourceQuantity>().setIronOre(FindObjectOfType<resourceQuantity>().getIronOre() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironOre, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Iron) && FindObjectOfType<resourceQuantity>().getIron() != 0)
            {
                FindObjectOfType<resourceQuantity>().setIron(FindObjectOfType<resourceQuantity>().getIron() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironBar, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperOre) && FindObjectOfType<resourceQuantity>().getCopperOre() != 0)
            {
                FindObjectOfType<resourceQuantity>().setCopperOre(FindObjectOfType<resourceQuantity>().getCopperOre() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperOre, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Copper) && FindObjectOfType<resourceQuantity>().getCopper() != 0)
            {
                FindObjectOfType<resourceQuantity>().setCopper(FindObjectOfType<resourceQuantity>().getCopper() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperBar, deliveryPoint.position);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Fiber) && FindObjectOfType<resourceQuantity>().getFiber() != 0)
            {
                FindObjectOfType<resourceQuantity>().setFiber(FindObjectOfType<resourceQuantity>().getFiber() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().fiber, deliveryPoint.position);
            }

            /*
             else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Food) && FindObjectOfType<resourceQuantity>().getFood() != 0)
            {
                FindObjectOfType<resourceQuantity>().setFood(FindObjectOfType<resourceQuantity>().getFood() - (int)value);
                instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().food);
            }

            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.Radioactive) && FindObjectOfType<resourceQuantity>().getNuclear() != 0)
            {
                FindObjectOfType<resourceQuantity>().setNuclear(FindObjectOfType<resourceQuantity>().getNuclear() - (int)value);
                instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().atomic);
            }
             */


            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.WoodPlanks) && FindObjectOfType<resourceQuantity>().getWoodPlank() != 0)
            {
                FindObjectOfType<resourceQuantity>().setWoodPlank(FindObjectOfType<resourceQuantity>().getWoodPlank() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().woodPlanks, deliveryPoint.position);
            }

            else if(menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperGear) && FindObjectOfType<resourceQuantity>().getCopperGear() > 0)
            {
                FindObjectOfType<resourceQuantity>().setCopperGear(FindObjectOfType<resourceQuantity>().getCopperGear() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperGear, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronGear) && FindObjectOfType<resourceQuantity>().getIronGear() > 0)
            {
                FindObjectOfType<resourceQuantity>().setIronGear(FindObjectOfType<resourceQuantity>().getIronGear() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironGear, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperPlate) && FindObjectOfType<resourceQuantity>().getCopperPlate() > 0)
            {
                FindObjectOfType<resourceQuantity>().setCopperPlate(FindObjectOfType<resourceQuantity>().getCopperPlate() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperPlate, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronPlate) && FindObjectOfType<resourceQuantity>().getIronPlate() > 0)
            {
                FindObjectOfType<resourceQuantity>().setIronPlate(FindObjectOfType<resourceQuantity>().getIronPlate() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironPlate, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.CopperWire) && FindObjectOfType<resourceQuantity>().getCopperWire() > 0)
            {
                FindObjectOfType<resourceQuantity>().setCopperWire(FindObjectOfType<resourceQuantity>().getCopperWire() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().copperWire, deliveryPoint.position);
            }
            else if (menager.resourceTypes.Equals(resourceMenager.ResourceTypes.IronWire) && FindObjectOfType<resourceQuantity>().getIronWire() > 0)
            {
                FindObjectOfType<resourceQuantity>().setIronWire(FindObjectOfType<resourceQuantity>().getIronWire() - (int)value);
                FindObjectOfType<craftingMenager>().instantiateByQuantity((int)value, FindObjectOfType<allPrefab>().ironWire, deliveryPoint.position);
            }

            maxRetrive(ResourceMenager);
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if(FindObjectOfType<buildingMenager>().isPlaced)
            {
                if (collision.gameObject.tag == "rawResource")
                {
                    GameObject resorce = collision.gameObject;
                    ResourceMenager = resorce.GetComponent<resourceMenager>();
                    ResourceMenager.deposit(sMenager);
                }
                if (collision.gameObject.tag == "rawBelt")
                {
                    GameObject resorce = collision.gameObject;
                    ConveyorBeltManager = resorce.GetComponent<conveyorBeltManager>();
                    ConveyorBeltManager.deposit(sMenager);
                }                
            }           
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<resourceQuantity>().setMaxSpace(FindObjectOfType<resourceQuantity>().getMaxSpace() - storageSpace);
        
    }
}
