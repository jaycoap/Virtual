using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBuilding : MonoBehaviour
{
    public int Circle_Building_maxHealth = 500;
    public int Circle_Health;
    public Animator anim;

    public HealthBar Circle_HealthBar;


    void Start()
    {
        Circle_Health = 0;
        Circle_HealthBar.SetMaxHealth(Circle_Building_maxHealth);
        //anim.SetBool("Building_State", true);

    }

    // Update is called once per frame
    public void Build_Circle()
    {
        Circle_Health = Circle_Health  + 100;
        Circle_HealthBar.SetHealth(Circle_Health);
    }
}
