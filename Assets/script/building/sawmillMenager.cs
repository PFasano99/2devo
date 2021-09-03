using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class sawmillMenager : MonoBehaviour
{
    public int internalWoodStorage;

    public int actualGoal;
    int flagGoal;
    int woodNeed = 0;
    public int timeToCraft = 0;

    public Transform deliveryPoint;


    public Text internalWood;
    public Text NeededWood;
    
    public Text maxCraftT;

    private Text[] allNeedeT;
    private GameObject[] allInitGo;
    private Text[] allInitT;
    private int[] allInternal;

    private Button[] allCraftingB;
    

    public Button woodPlanksB;

    public Button craftB;
    public Text craftT;

    public Slider sliderCraft;
    
    public Toggle caWoodPlanks;

    private resourceMenager ResourceMenager = new resourceMenager();

    private Coroutine craftRoutine = null;

    // Start is called before the first frame update
    void Start()
    {
        allNeedeT = new Text[] { NeededWood };
        allCraftingB = new Button[] { woodPlanksB };
        allInitGo = new GameObject[] { FindObjectOfType<allPrefab>().wood };
        allInitT = new Text[] { internalWood};
        allInternal = new int[] {internalWoodStorage };


        sliderCraft.GetComponent<Slider>();
        sliderCraft.onValueChanged.AddListener(delegate { changeSliderBy2(sliderCraft, sliderCraft.value, craftT, NeededWood); });

        woodPlanksB.GetComponent<Button>();
        woodPlanksB.onClick.AddListener(delegate {
            ResourceMenager.resourceTypes = resourceMenager.ResourceTypes.WoodPlanks;
            ResourceMenager.timeToProduce = 3;

            checkMaxCraft("woodPlanks");
            FindObjectOfType<craftingMenager>().resetButtonColor(woodPlanksB, craftT, sliderCraft, allCraftingB);
            FindObjectOfType<craftingMenager>().resetNeedT(allNeedeT);
        });

        craftB.GetComponent<Button>();
        craftB.onClick.AddListener( delegate { craft(ResourceMenager); });
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void checkMaxCraft(string type)
    {
        if(type.Equals("woodPlanks"))
            FindObjectOfType<craftingMenager>().maxCraft(internalWoodStorage * 2, sliderCraft, maxCraftT);
    }
   

    public void changeSliderBy2(Slider s, float value, Text display, Text displayWood)
    {
        flagGoal = (int)value;
        if (flagGoal%2 != 0)
        {
            flagGoal++;
        }
        s.SetValueWithoutNotify(flagGoal);
        display.text = "Make: " + flagGoal;
        woodNeed = flagGoal / 2;
        displayWood.text = "" + woodNeed;
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
      if (menager.resourceTypes == resourceMenager.ResourceTypes.WoodPlanks && internalWoodStorage > 0)
      {
        actualGoal = (int) sliderCraft.value;
        internalWoodStorage -= actualGoal / 2;
            checkMaxCraft("woodPlanks");
            craftRoutine = StartCoroutine(productionTimeTick(menager.timeToProduce, FindObjectOfType<allPrefab>().woodPlanks, 2));                  
      }
        allInternal = new int[] { internalWoodStorage };
        FindObjectOfType<craftingMenager>().internalStorageDisplay(allInitT, allInternal);
    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.gameObject.tag == "rawResource" && FindObjectOfType<buildingMenager>().isPlaced)
            {
                GameObject resource = collision.gameObject;
                resourceMenager rm = resource.GetComponent<resourceMenager>();
                if(rm.resourceTypes == resourceMenager.ResourceTypes.Wood)
                {
                    internalWoodStorage += rm.quantity;
                    Destroy(resource);
                }

                allInternal = new int[] { internalWoodStorage };
                FindObjectOfType<craftingMenager>().internalStorageDisplay(allInitT, allInternal);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void OnDestroy()
    {
        allInternal = new int[] { internalWoodStorage };
        FindObjectOfType<craftingMenager>().multipleCrafting(allInternal, allInitGo, deliveryPoint.position);
    }

}
