using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScoll : MonoBehaviour
{
    public float ScrollSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        
        pos.x = pos.x - (ScrollSpeed * Time.deltaTime);
        //Time.deltatime = เวลาทุกวินาที ทำให้ต่อให้ fps ไม่เท่ากันเกมจะดำเนินเท่ากันแก้frame rate ไม่คงที่
        this.transform.position = pos;
    }
}
