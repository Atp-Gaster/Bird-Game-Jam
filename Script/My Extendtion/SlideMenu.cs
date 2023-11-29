using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMenu : MonoBehaviour
{
    [SerializeField] private Vector3 firstPosition;
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private float speed;
    private Vector3 movingDirection;
    [SerializeField] private bool Trigger = false;

    public GameObject Cutseen;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RectTransform>().localPosition = firstPosition;
        movingDirection = finalPosition - firstPosition;
        Invoke("MoveIn",20);
    }
    void MoveIn()
    {
        Destroy(Cutseen.gameObject);
        Trigger = true;        
    }
    // Update is called once per frame
    void Update()
    {
        if(Trigger)
        {
            if (Vector3.Distance(gameObject.GetComponent<RectTransform>().localPosition,firstPosition) > movingDirection.magnitude)
            {
                gameObject.GetComponent<RectTransform>().localPosition = finalPosition;
                this.enabled = false;
            }
            else
            {
                //linear equalation
                gameObject.GetComponent<RectTransform>().localPosition
                    = gameObject.GetComponent<RectTransform>().localPosition + (movingDirection * Time.deltaTime * speed * 0.01f);
            }
        }
        
    }
}
