using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Platform : MonoBehaviour
{
    public int CountBeforeDestroy = 0;

    void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("enterd the area");
        if (collision.tag == "Player")
        {
            print("Test");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit the area");
        if (collision.tag == "Player")
        {
            CountBeforeDestroy--;
            Debug.Log("Count to destroy: " + CountBeforeDestroy); 
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CountBeforeDestroy <= 0) Invoke("DestroyGameObject", 1.0f);
    }
}
