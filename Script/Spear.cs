using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public int StageAnim = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (StageAnim == 0) this.GetComponent<Animator>().SetBool("Isground", true ); //Down

        if (StageAnim == 1) this.GetComponent<Animator>().SetBool("Isground", false); //throw

        //Appearantly Box Collider is bigger than size of normal Scale by 1.6
        //for some reason
        Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position, transform.GetComponent<BoxCollider2D>().size / 1.6f, 0);
        foreach (Collider2D col in collider)
        {
            if (col.gameObject.CompareTag("BunnyCatch"))
            {
                //col.gameObject.GetComponentInParent<FoxBehaviour>().Death();
            }

            if (col.gameObject.CompareTag("Ground"))
            {
                StageAnim = 0;
                Destroy(gameObject, 4);
                if(StageAnim == 1) Destroy(gameObject,1);
            }
        }
    }
}
