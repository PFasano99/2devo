using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalInformations : MonoBehaviour
{
    [Header("Duration in seconds")]
    public int nightDuration, dayDuration;
    [Header("Number of days")]
    public int winterDayDuration, summerDayDuration, springDayDuration, autumnDayDuration;

    [Space]
    public bool isNight = false;

    [Space]
    public int daysToNextSeason, totDays;

    [Space]

    Coroutine dayNightCoroutine = null;
    public enum Season { Summer, Winter, Spring, Autumn };
    public Season season;

    // Start is called before the first frame update
    void Start()
    {
        dayNightCoroutine = StartCoroutine(dayCycleTimeTick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dayCycleTimeTick()
    {

        while (true)
        {
            
            yield return new WaitForSeconds(dayDuration);
            isNight = true;

            yield return new WaitForSeconds(nightDuration);
            isNight = false;

            totDays++;
            daysToNextSeason--;
            if (daysToNextSeason <= 0)
                changeSeason();
        }
    }

    public void changeSeason()
    {
        if(Season.Summer == season)
        {
            season = Season.Autumn;
            daysToNextSeason = autumnDayDuration;
        }
        else if (Season.Autumn == season)
        {
            season = Season.Winter;
            daysToNextSeason = winterDayDuration;
        }
        else if (Season.Winter == season)
        {
            season = Season.Spring;
            daysToNextSeason = springDayDuration;
        }
        else
        {
            season = Season.Summer;
            daysToNextSeason = summerDayDuration;
        }
    }

}
