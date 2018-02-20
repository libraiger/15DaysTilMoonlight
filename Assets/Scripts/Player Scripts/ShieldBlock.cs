﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlock : MonoBehaviour
{

    public BoxCollider2D shieldBlock;

    private HurtPlayer damageControl;

    public int damageTest;

    public bool shieldOn;

    private float axisInput;

    private PlayerStaminaManager playerStaminaMan;
    private PlayerController thePlayer;
    public bool shieldLockBool; //bool to make player blocking more dynamic (shield is turned off when hit)

    // Use this for initialization
    void Start()
    {
        playerStaminaMan = FindObjectOfType<PlayerStaminaManager>();

        thePlayer = FindObjectOfType<PlayerController>();

        FindObjectOfType<HurtPlayer>();

        shieldOn = false;

        shieldLockBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        axisInput = Input.GetAxisRaw("BlockX");

        if (playerStaminaMan.playerCurrentStamina <= 0)
        {
            shieldBlock.isTrigger = true;
            shieldOn = false;
        }

        if (axisInput >= 0.2f && playerStaminaMan.playerCurrentStamina > 0 
            && thePlayer.preAttackCounter == 0.2f && thePlayer.recovAttackCounter == 0.3f 
            && thePlayer.attackingCounterNew == 0.06f && !shieldLockBool)
        {
            shieldBlock.isTrigger = false;
            shieldOn = true;
        }

        if (axisInput <= 0f || shieldLockBool)
        {
            shieldBlock.isTrigger = true;
            shieldOn = false;
        }

        if(axisInput <= 0){
            shieldLockBool = false;
        }

        if (Input.GetButton("Block") && shieldOn == false && playerStaminaMan.playerCurrentStamina > 0)
        {
            shieldBlock.isTrigger = false;
            shieldOn = true;
        }

        else if (Input.GetButton("Block") && shieldOn == true)
        {
            shieldBlock.isTrigger = true;
            shieldOn = false;
        }
    }
}
