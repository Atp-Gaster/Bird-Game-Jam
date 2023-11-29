using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    private void OnDrawGizmos()
    {
        Vector4 color = new Vector4(1, 1, 0, 0.23f);
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1);
        foreach (Collider2D col in collider)
        {
            if (col.transform.CompareTag("Player") && col.TryGetComponent(out FoxBehaviour p)) // finding if they are player.
            {
                col.gameObject.AddComponent<ItemEffect>();
                Destroy(gameObject);
            }
        }
    }
}
