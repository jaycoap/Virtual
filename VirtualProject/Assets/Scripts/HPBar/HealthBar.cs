using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //슬라이더 변수선언 
    //public Image fill; //공개 이미지를 만들어 참조

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; 
        slider.value = 0;

    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
