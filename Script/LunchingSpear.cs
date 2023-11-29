using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchingSpear : MonoBehaviour
{
    public GameObject Spear;
    private FoxBehaviour Player;
    [SerializeField] private Vector2 SpearPower;
    public void LunchSpaer ()
    {
        Player = gameObject.GetComponent<FoxBehaviour>();
        GameObject cloneSpear = Instantiate(Spear) as GameObject;
        cloneSpear.transform.position = transform.position;
        if(Player.GetComponentInChildren<SpriteRenderer>().flipX)
        {        
            cloneSpear.GetComponent<Rigidbody2D>().AddForce(SpearPower);
        }
        else
        {
            SpearPower.x = SpearPower.x * -1;
            SpearPower.y = SpearPower.y * 1;
            cloneSpear.GetComponent<Rigidbody2D>().AddForce(SpearPower);
        }

    }

}
