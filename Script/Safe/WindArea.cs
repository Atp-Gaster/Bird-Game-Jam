using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Vector3 windForce;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDrawGizmos(){
        Vector4 color = new Vector4 (1,1,0,0.2f);
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, transform.lossyScale); 
    }

    void Update()
    {
        if (CheckPlayer())
        {
            Blown();
        }
    }

    bool CheckPlayer()
    {
        Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position, transform.lossyScale, 0);
        foreach (Collider2D col in collider)
        {
            if (col.transform.CompareTag("Player")) return true;
        }
        return false;
    }

    void Blown()
    {
        player.transform.position += Time.deltaTime * windForce;
    }
}
