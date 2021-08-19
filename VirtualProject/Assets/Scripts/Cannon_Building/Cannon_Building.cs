﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Building : MonoBehaviour
{
    public int Cannon_Struct_maxHealth = 500;
    public int Cannon_Health;
    public Animator anim;
    public SpriteRenderer Cannon_spriteRenderer;
    public Sprite Cannon_Complete_Sprite;

    Animator Cannon_Animator;

    public HealthBar Cannon_HealthBar;


    void Start()
    {
        Cannon_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Cannon_Health = 0;
        Cannon_HealthBar.SetMaxHealth(Cannon_Struct_maxHealth);
        Cannon_Animator = GetComponent<Animator>();
        Cannon_Animator.SetBool("Building", true);
        

    }

    // Update is called once per frame
    public void Build_Cannon()
    {
        Cannon_Health = Cannon_Health + 1;

        if (Cannon_Health >= Cannon_Struct_maxHealth || Cannon_Health == Cannon_Struct_maxHealth)
        {
            Cannon_Health = Cannon_Struct_maxHealth;
            Cannon_HealthBar.SetHealth(Cannon_Struct_maxHealth);
            Cannon_Animator.SetBool("Building", false);
            

        }    
        else
        {
            Cannon_HealthBar.SetHealth(Cannon_Health);
        }
    }

    public void Complete()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Cannon_Complete_Sprite;

    }
}
