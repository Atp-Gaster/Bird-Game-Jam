using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggle : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private bool isItemPauseUI;

    public void CloseItem()
    {
        targetObject.SetActive(false);
        if (isItemPauseUI) //need to check if the item is Pause UI (Pause when Active)
        {
            Time.timeScale = 1;
        }
    }
    public void OpenItem()
    {
        targetObject.SetActive(true); 
        if (isItemPauseUI) //need to check if the item is Pause UI (Pause when Active)
        {
            Time.timeScale = 0;
        }
    }
}
