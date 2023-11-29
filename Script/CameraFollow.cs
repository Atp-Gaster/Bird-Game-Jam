using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//let camera follow target
public class CameraFollow2 : MonoBehaviour
{
    public Transform Currenttarget;
    public float lerpSpeed = 1.0f;

    private Vector3 offset;

    private Vector3 targetPos;

    public void Change_Current_target(Transform target)
    {
        Currenttarget = target;
    }

    private void Start()
    {
        if (Currenttarget == null) return;

        offset = transform.position - Currenttarget.position;
    }

    private void Update()
    {
        if (Currenttarget == null) return;

        targetPos = Currenttarget.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }

}

