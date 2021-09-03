using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeGrowth : MonoBehaviour
{
    [Header("Sprite by season")]
    public Sprite[] stageSummer;
    public Sprite[] stageAutumn;
    public Sprite[] stageWinter;
    public Sprite[] stageSpring;

    [Header("Min and Max time next stage")]
    [Tooltip("Time before the tree grows to next stage min and max time")]
    public float[] timeBeforeChanageMin;
    public float[] timeBeforeChanageMax;

    [Header("Range of item drop value")]
    public float[] rangeOfDropMin;
    public float[] rangeOfDropMax;

    [Header("Number of hits by stage")]
    public int[] resourceHealt;

    [Space]
    public int stage;

    Coroutine growingRoutine = null;
    Coroutine seasonRoutine = null;

    [Space]
    public string currentSeason = "Summer";

    [Header("has at least one season change")]
    public bool changesSeason;
    [Header("change in this season")]
    public bool changeInSummer; public bool changeInAutumn, changeInWinter, changeInSpring;

    [Space]
    public int nOfSeasonChange;

    [Space]
    public Vector2[] colliderSize;
    public Vector2[] colliderOffset, colliderTriggerSize, colliderTriggerOffset;

    [Space]
    public BoxCollider2D triggered, colliderNotTrigger;
    // Start is called before the first frame update
    void Start()
    {
        currentSeason = FindObjectOfType<generalInformations>().season.ToString();
        stage = Random.Range(0, 3);
        gameObject.GetComponent<SpriteRenderer>().sprite = stageSummer[stage];

        treeGrowthValues(stage);

        if (stage < 2)
        {
            growingRoutine = StartCoroutine(growTimeTick(Random.Range(timeBeforeChanageMin[stage], timeBeforeChanageMax[stage])));
        }

        if (changesSeason)
        {
            seasonRoutine = StartCoroutine(seasonTimeTick());
        }

    }


    /*
     * changes the valuses of the number of hits needed to destroy the tree, the number of pieces of wood dropped the size and offset 
     * of the collider and triggered collider
     */
    public void treeGrowthValues(int i)
    {
        //to remove after testing
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.1f);

        if (gameObject.GetComponent<NodeMenager>())
        {
            gameObject.GetComponent<NodeMenager>().resourceHealt = resourceHealt[stage];
            gameObject.GetComponent<NodeMenager>().AvailableResource = Random.Range(rangeOfDropMin[i], rangeOfDropMax[i]);

        }
    
        if (i > 0)
        {  
            colliderNotTrigger.offset = colliderOffset[i - 1];
            colliderNotTrigger.size = colliderSize[i - 1];

            triggered.offset = colliderTriggerOffset[i - 1];
            triggered.size = colliderTriggerSize[i - 1];
        }
        

    }

    /*
     * if the stage is not the last one, it waits for X seconds that is the time before the change to the next stage, then
     * it changes the sprite for the tree based on the stage of growth and season  
     */
    IEnumerator growTimeTick(float second)
    {

        while (true)
        {
            yield return new WaitForSeconds(second);

            stage++;
            if (currentSeason == "Summer")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = stageSummer[stage];
            }
            else if (currentSeason == "Winter")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = stageWinter[stage];
            }
            else if (currentSeason == "Spring")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = stageSpring[stage];
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = stageAutumn[stage];
            }

            treeGrowthValues(stage);

            StopCoroutine(growingRoutine);

            if (stage < 2)
            {
                growingRoutine = StartCoroutine(growTimeTick(Random.Range(timeBeforeChanageMin[stage], timeBeforeChanageMax[stage])));
            }

        }
    }

    /*
     * this method changes the sprite based on the change of the season if the tree has the specific season it gets a delay, then 
     * it waits a number of days * the delay then change the sprote (so that not all the trees changes at the same time)
     * then it waits for the season to change before checking again
     */
    IEnumerator seasonTimeTick()
    {

        while (true)
        {
            int delayForChange = 1;

            if (currentSeason != FindObjectOfType<generalInformations>().season.ToString())
            {              
                currentSeason = FindObjectOfType<generalInformations>().season.ToString();
                if (currentSeason == "Summer" && changeInSummer)
                {
                    delayForChange = (int)Random.Range(0, FindObjectOfType<generalInformations>().summerDayDuration / 3f);
                    yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * delayForChange);
                    gameObject.GetComponent<SpriteRenderer>().sprite = stageSummer[stage];
                    yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * FindObjectOfType<generalInformations>().summerDayDuration - delayForChange * 2f);
                }
                else if (currentSeason == "Winter" && changeInWinter)
                {
                    delayForChange = (int)Random.Range(0, FindObjectOfType<generalInformations>().winterDayDuration / 3f);
                    yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * delayForChange);
                    gameObject.GetComponent<SpriteRenderer>().sprite = stageWinter[stage];
                    yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * FindObjectOfType<generalInformations>().winterDayDuration - delayForChange);
                }
                else if (currentSeason == "Spring" && changeInSpring)
                {
                    delayForChange = (int)Random.Range(0, FindObjectOfType<generalInformations>().springDayDuration / 3f);
                    yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * delayForChange);
                    gameObject.GetComponent<SpriteRenderer>().sprite = stageSpring[stage];
                    yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * FindObjectOfType<generalInformations>().springDayDuration - delayForChange);
                }
                else if (changeInAutumn)
                {
                    delayForChange = (int)Random.Range(0, FindObjectOfType<generalInformations>().autumnDayDuration / 3f);
                    yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * delayForChange);
                    gameObject.GetComponent<SpriteRenderer>().sprite = stageAutumn[stage];
                    yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * FindObjectOfType<generalInformations>().autumnDayDuration - delayForChange);
                }
            }
            else
            {
                yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * FindObjectOfType<generalInformations>().autumnDayDuration);
            }

            yield return new WaitForSeconds((FindObjectOfType<generalInformations>().dayDuration + FindObjectOfType<generalInformations>().nightDuration) * delayForChange + 1f);

        }

    }

}
