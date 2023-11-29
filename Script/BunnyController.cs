using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    [Header("Setting")]
    public Transform Bunny;
    public int Timer = 0;
    public int Player = 1;
    [SerializeField] int UpRange = 0;
    void upward ()
    {
        //Debug.LogWarning("Upward");
        //Transform CurrentPosition = Bunny.GetComponent<Rigidbody2D>().velocity = dashSpeed * dir;
        transform.parent.position = new Vector3(Bunny.position.x, Bunny.position.y + UpRange + 6, Bunny.position.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        if(Player == 1) InvokeRepeating("upward", Timer, Timer);
        if (Player == 2) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
