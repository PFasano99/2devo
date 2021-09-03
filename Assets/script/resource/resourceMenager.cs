using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class resourceMenager : MonoBehaviour
{
    public enum ResourceTypes { Wood, Stone, Food, Radioactive, Water, Iron, IronOre, Fiber, Population, Coal, CopperOre, Copper, WoodPlanks, CopperWire, CopperPlate, CopperGear, IronWire, IronPlate, IronGear, Belt};
    public ResourceTypes resourceTypes;

    public int quantity;
    public int value;
    public int timeToProduce= 0;

    public Image quantityP;
    public Text quantityT;

    public Button closeB, splitB, confirmSplitB;
    public Image splitPanel;
    public Slider splitSlider;
    public Text splitT;
    public int splitValue;

    // Start is called before the first frame update
    void Start()
    {
        if (quantity < 2)
            splitT.text = "X";
                    

        quantityP.GetComponent<Image>();
        quantityP.gameObject.SetActive(false);

        splitPanel.GetComponent<Image>();
        splitPanel.gameObject.SetActive(false);

        quantityT.GetComponent<Text>();
        quantityT.text = quantity.ToString();

        splitSlider.GetComponent<Slider>();
        splitSlider.onValueChanged.AddListener(delegate {
            if(quantity>1)
            {
                splitT.text = splitSlider.value.ToString();              
            }
            
            else
                splitT.text = "X";
        });

        closeB.GetComponent<Button>();
        closeB.onClick.AddListener(delegate { close(); });

        splitB.GetComponent<Button>();
        splitB.onClick.AddListener(delegate { split(); });

        confirmSplitB.GetComponent<Button>();
        confirmSplitB.onClick.AddListener(delegate { actualSplit(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void split()
    {
        FindObjectOfType<UIMenager>().setPanelVisibility(splitPanel);

        if (quantity > 1)
        {
            resetSlide();            
        }        
    }

    public void actualSplit()
    {
        Vector3 spawnPosition;
        spawnPosition = transform.position + new Vector3(1.5f, 0, 0);
        splitValue = (int)splitSlider.value;
        if(splitValue>0 && quantity>1)
        {
            GameObject go = pickResource();

            resourceMenager toSpawn = go.GetComponent<resourceMenager>();
            toSpawn.quantity = splitValue;

            FindObjectOfType<craftingMenager>().actualCraft(toSpawn.gameObject, spawnPosition);
 
            quantity -= splitValue;
            quantityT.text = quantity.ToString();

            if (quantity < 2)
                splitT.text = "X";
            else
                resetSlide();

        }
        else
        {
            splitT.text = "X";
        }

        
    }

    public void resetSlide()
    {
        splitSlider.SetValueWithoutNotify(1);
        splitSlider.maxValue = quantity - 1;
        splitT.text = "1";
        splitValue = 0;
    }

    public GameObject pickResource()
    {
        GameObject resource = new GameObject();
        if (resourceTypes.Equals(ResourceTypes.Wood))
            resource = FindObjectOfType<allPrefab>().wood;

        else if (resourceTypes.Equals(ResourceTypes.Stone))
            resource = FindObjectOfType<allPrefab>().stone;

        else if (resourceTypes.Equals(ResourceTypes.Iron))
            resource = FindObjectOfType<allPrefab>().ironBar;

        else if (resourceTypes.Equals(ResourceTypes.IronOre))
            resource = FindObjectOfType<allPrefab>().ironOre;

        else if (resourceTypes.Equals(ResourceTypes.Food))
            resource = FindObjectOfType<allPrefab>().fiber;

        else if (resourceTypes.Equals(ResourceTypes.Radioactive))
            resource = FindObjectOfType<allPrefab>().wood;

        else if (resourceTypes.Equals(ResourceTypes.Coal))
            resource = FindObjectOfType<allPrefab>().coal;

        else if (resourceTypes.Equals(ResourceTypes.Copper))
            resource = FindObjectOfType<allPrefab>().copperBar;

        else if (resourceTypes.Equals(ResourceTypes.CopperOre))
            resource = FindObjectOfType<allPrefab>().copperOre;

        else if (resourceTypes.Equals(ResourceTypes.WoodPlanks))
            resource = FindObjectOfType<allPrefab>().woodPlanks;

        else if (resourceTypes.Equals(ResourceTypes.Fiber))
            resource = FindObjectOfType<allPrefab>().fiber;

        else if (resourceTypes.Equals(ResourceTypes.CopperWire))
            resource = FindObjectOfType<allPrefab>().copperWire;

        else if (resourceTypes.Equals(ResourceTypes.IronWire))
            resource = FindObjectOfType<allPrefab>().ironWire;

        else if (resourceTypes.Equals(ResourceTypes.CopperGear))
            resource = FindObjectOfType<allPrefab>().copperGear;

        else if (resourceTypes.Equals(ResourceTypes.IronGear))
            resource = FindObjectOfType<allPrefab>().ironGear;

        else if (resourceTypes.Equals(ResourceTypes.CopperPlate))
            resource = FindObjectOfType<allPrefab>().copperPlate;

        else if (resourceTypes.Equals(ResourceTypes.IronPlate))
            resource = FindObjectOfType<allPrefab>().ironPlate;

        return resource;
    }

    public void close()
    {
        quantityP.gameObject.SetActive(false);      
    }
    public void setQuantity(int value)
    {
        quantity = value;
        quantityT.text = quantity.ToString();
    }

    public void sell()
    {
        int money = 0;
        money = value * quantity;
        FindObjectOfType<resourceQuantity>().setCoin(FindObjectOfType<resourceQuantity>().getCoins()+ money);
        Destroy(gameObject);
    }

    public void deposit(storageMenager storage)
    {
       
        int maxFlag = FindObjectOfType<resourceQuantity>().getCurrentQuantity() + quantity;
        if (maxFlag < FindObjectOfType<resourceQuantity>().getMaxSpace())
        {
            FindObjectOfType<resourceQuantity>().setCurrentQuantity(maxFlag);
            if (resourceTypes.Equals(ResourceTypes.Wood))
                FindObjectOfType<resourceQuantity>().setWood(FindObjectOfType<resourceQuantity>().getWood() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.Stone))
                FindObjectOfType<resourceQuantity>().setStone(FindObjectOfType<resourceQuantity>().getStone() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.Iron))
                FindObjectOfType<resourceQuantity>().setIron(FindObjectOfType<resourceQuantity>().getIron() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.IronOre))
                FindObjectOfType<resourceQuantity>().setIronOre(FindObjectOfType<resourceQuantity>().getIronOre() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.Food))
                FindObjectOfType<resourceQuantity>().setFood(FindObjectOfType<resourceQuantity>().getFood() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.Radioactive))
                FindObjectOfType<resourceQuantity>().setNuclear(FindObjectOfType<resourceQuantity>().getNuclear() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.Coal))
                FindObjectOfType<resourceQuantity>().setCoal(FindObjectOfType<resourceQuantity>().getCoal() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.Copper))
                FindObjectOfType<resourceQuantity>().setCopper(FindObjectOfType<resourceQuantity>().getCopper() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.CopperOre))
                FindObjectOfType<resourceQuantity>().setCopperOre(FindObjectOfType<resourceQuantity>().getCopperOre() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.WoodPlanks))
                FindObjectOfType<resourceQuantity>().setWoodPlank(FindObjectOfType<resourceQuantity>().getWoodPlank() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.Fiber))
                FindObjectOfType<resourceQuantity>().setFiber(FindObjectOfType<resourceQuantity>().getFiber() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.CopperWire))
                FindObjectOfType<resourceQuantity>().setCopperWire(FindObjectOfType<resourceQuantity>().getCopperWire() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.IronWire))
                FindObjectOfType<resourceQuantity>().setIronWire(FindObjectOfType<resourceQuantity>().getIronWire() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.CopperGear))
                FindObjectOfType<resourceQuantity>().setCopperGear(FindObjectOfType<resourceQuantity>().getCopperGear() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.IronGear))
                FindObjectOfType<resourceQuantity>().setIronGear(FindObjectOfType<resourceQuantity>().getIronGear() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.CopperPlate))
                FindObjectOfType<resourceQuantity>().setCopperPlate(FindObjectOfType<resourceQuantity>().getCopperPlate() + quantity);

            else if (resourceTypes.Equals(ResourceTypes.IronPlate))
                FindObjectOfType<resourceQuantity>().setIronPlate(FindObjectOfType<resourceQuantity>().getIronPlate() + quantity);

            Destroy(gameObject);
        }
        else
        {           
            storage.noSpace();
        }       
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="player")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                quantityP.gameObject.SetActive(true);
                quantityT.text = quantity.ToString();
            }
        }
        
    }
}
