using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlidingGauge : MonoBehaviour
{
    private Slider gauge;
    [SerializeField] private FoxBehaviour player;
    // Start is called before the first frame update
    void Start()
    {
        gauge = this.GetComponent<Slider>();
        gauge.maxValue = player.maxGilde;
        gameObject.SetActive(false);
    }

    void Update()
    {
        gauge.value = player.Glide;
        if (player.Glide <= 0)
        {

            gameObject.SetActive(false);
            gauge.value = player.maxGilde;

        }

    }
}
