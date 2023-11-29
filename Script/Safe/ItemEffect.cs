using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Effect());
    }

    protected IEnumerator Effect() 
    { 
        FoxBehaviour player = transform.GetComponent<FoxBehaviour>();
        player.SetMoveSpeed(10);
        yield return new WaitForSeconds(3);
        player.SetMoveSpeed(5);
        Destroy(this); 
    }
}
