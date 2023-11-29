using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool OriginalPrefab;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground" && !OriginalPrefab)
        {
            Destroy(gameObject);
        }
    }

    public void Setprefab()
    {
        OriginalPrefab = false;
    }

    void Start()
    {
        if(!OriginalPrefab) Destroy(gameObject, 15);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
