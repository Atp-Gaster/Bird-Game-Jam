using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private Slider slider;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = audioSource.volume;
    }
    void Update()
    {
        audioSource.volume = Mathf.Round(slider.value * 100)/100; //2 digit number also making 0.04 on middle
        //max is 1 min is 0
    }
}
