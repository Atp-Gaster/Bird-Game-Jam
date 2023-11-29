using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBunny : MonoBehaviour
{
    public Transform BunnySpawn;
    public int SpawnId = 0;
 

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerCatch"))
        {
            Debug.Log("Respawn Start!");            
            GameObject bun = GameObject.FindWithTag("Bunny");
            GameObject carrot = GameObject.FindWithTag("Player");

            if (Vector3.Distance(bun.transform.position, carrot.transform.position) >= 20 )
            {
                bun.transform.position = BunnySpawn.transform.position;
            }
            //GameObject.FindWithTag("Bunny").GetComponent<FoxBehaviour>().Respawn(SpawnId);
            //GameObject.Find("Bunny_Player").transform.position = BunnySpawn.transform.position;
        }
    }


}
