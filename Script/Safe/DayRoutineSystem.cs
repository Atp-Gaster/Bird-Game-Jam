using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayRoutineSystem : MonoBehaviour
{
    private Light spotlight;
    [SerializeField] float duration = 60;
    float actualTime;
    bool nightTime;
    // Start is called before the first frame update
    void Start()
    {
        nightTime = true;
        actualTime = 0;
        
        spotlight = GetComponent<Light>();
        SwitchTime();
        StartCoroutine(Cycle());
    }


    private IEnumerator Cycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (actualTime <= duration)
            {
                actualTime++;

            }
            else
            {
                actualTime = 0;
                SwitchTime();
            }
        }

    }

    void SwitchTime()
    {
        nightTime = !nightTime;
        if (nightTime)
        {
            spotlight.range = 100;
            spotlight.spotAngle = 24;
        }
        else
        {
            spotlight.range = 10000;
            spotlight.spotAngle = 180;
        }
    }

}