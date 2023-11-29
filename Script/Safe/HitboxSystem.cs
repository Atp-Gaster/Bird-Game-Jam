using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxSystem : MonoBehaviour
{
    public FoxBehaviour player;    
    public AudioClip DMGSound;
    void Start()
    {
        
    }
    //Hitbox with enemy 
    //private void OnTriggerEnter2D(Collider2D other)
   // {
    //    if(player.PlayerType == 0)
    //    if (other.tag == "BunnyCatch")//Extendtion System: Hitpoint System
     //   {
     //           Debug.Log(other.GetComponent<FoxBehaviour>().Iskillable); 

     ///   }

        

    //}

   

    void takeDMGSFX()
    {
        this.GetComponent<AudioSource>().PlayOneShot(DMGSound);
    }

}