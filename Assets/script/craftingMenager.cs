using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class craftingMenager : MonoBehaviour
{
    private Color c = new Color32(112, 100, 90, 255);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateByQuantity(int value, GameObject toSpawn, Vector3 spawnPosition)
    {
        if(value>0)
        {
            GameObject gameObject = (GameObject)Instantiate(toSpawn, spawnPosition, Quaternion.identity);
            gameObject.GetComponent<resourceMenager>().setQuantity((int)value);
        }        
               
    }

    public void actualCraft(GameObject toSpawn, Vector3 spawnPosition)
    {
        GameObject gameObject = (GameObject)Instantiate(toSpawn, spawnPosition, Quaternion.identity);
    }

    public void resetButtonColor(Button toChange, Text display, Slider s, Button[] allButtons)
    {      
        for (int i = 0; i < allButtons.Length; i++)
            allButtons[i].GetComponent<Image>().color = c;
                    
        toChange.GetComponent<Image>().color = Color.green;
        display.text = "Craft ";
        s.SetValueWithoutNotify(0f);      
    }

    public void resetNeedT(Text[] needT)
    {
        for (int i = 0; i < needT.Length; i++)
            needT[i].text = "0";      
    }

    public void maxCraft(float value, Slider sliderCraft, Text maxCraftT)
    {
        sliderCraft.maxValue = value;
        maxCraftT.text = "MAX:" + value.ToString();
    }

    public void multipleCrafting(int[] quantity,  GameObject[] toSpawn, Vector3 spawnPosition)
    {
        for (int i = 0; i < toSpawn.Length; i++)
        {          
          instantiateByQuantity(quantity[i], toSpawn[i], spawnPosition);
            if(quantity[i]>0)
            {
                if(quantity[i] % 2 != 0)
                spawnPosition += new Vector3(0, 1.5f, 0);

                else
                spawnPosition += new Vector3(1.5f, 0, 0);
            }                           
        }
    }

    public void internalStorageDisplay(Text[] internalT, int[] init)
    {      
        for (int i = 0; i < internalT.Length; i++)
            internalT[i].text = init[i].ToString();
    }

    IEnumerator productionTimeTick(float second, GameObject gameObject, int madePerCraft, Vector3 spawnPoint, int goal, Coroutine craftRoutine)
    {
        while (true)
        {
            do
            {
                yield return new WaitForSeconds(second);
                actualCraft(gameObject, spawnPoint);
                goal -= madePerCraft;

            } while (goal > 0);

            StopCoroutine(craftRoutine);
        }
    }


}
