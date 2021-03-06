using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image point;

    public void SetMaxHealth(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;

        gradient.Evaluate(1f);
    }

    public void SubtractHealth(int damage)
    {
        slider.value -= damage;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
