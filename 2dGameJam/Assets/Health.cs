using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    // Start is calledre the first frame update
    public void setMax(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void set_health(int health)
    {
        slider.value = health;
    }
}
