using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public FoxBehaviour player;

    void Update()
    {
        if (player.HP == 3)
        {   //Setint in Animation parameter
            this.GetComponent<Animator>().SetInteger("HPPoint", 3);
            
        }

        if (player.HP == 2)
        {   //Setint in Animation parameter
            this.GetComponent<Animator>().SetInteger("HPPoint", 2);
        }

        if (player.HP == 1)
        {   //Setint in Animation parameter
            this.GetComponent<Animator>().SetInteger("HPPoint", 1);
        }

        if (player.HP == 0)
        {   //Setint in Animation parameter
            this.GetComponent<Animator>().SetInteger("HPPoint", 0);
        }
    }
}
