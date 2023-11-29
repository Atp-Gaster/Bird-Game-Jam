using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemController : MonoBehaviour
{
    public int EffectID = 0;
    public int PlayerType = 0; // 0 = Carrot , 1 Rabbit

    public Animator animator_Carrots;    
    public Animator animator_Bunny;
    public FoxBehaviour foxBehaviour;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BunnyCatch")//Extendtion System: Hitpoint System
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerType == 0)
        {
          
            switch (EffectID)
            {
                case 1: animator_Carrots.SetTrigger("UseSpear");
                        EffectID = 0;
                        break;
             
            }            
        }
        
    }
}
