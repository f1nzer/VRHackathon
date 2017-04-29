﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Smoke,
    Fire
}

public static class Data
{
    static Data()
    {
        OxygenAmount = 1;
        BurnsAmount = 0;
    }

    public static MainController Controller { get; set; }

    public static float FloorHeight { get; set; }
    public static bool IsSmokeActivated { get; set; }    

    public static float OxygenAmount { get; set; }
    public static float BurnsAmount { get; set; }

    public static float GetSmokeHeight()
    {
        return FloorHeight + 1.3f;
    }
    
    public static void DamagePlayer(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Fire:
                BurnsAmount += 0.001f;
                break;

            case DamageType.Smoke:
                OxygenAmount -= 0.002f;
                break;

            default:
                break;
        }

        if (BurnsAmount >= 1 || OxygenAmount <= 0)
        {
            Controller.KillPlayer();
        }
        
        if (BurnsAmount >= 1)
        {
            BurnsAmount = 1;
        }

        if (OxygenAmount <= 0)
        {
            OxygenAmount = 0;
        }
    }

    public static void HealPlayer(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Fire:
                BurnsAmount -= 0.001f;
                break;

            case DamageType.Smoke:
                OxygenAmount += 0.001f;
                break;

            default:
                break;
        }

        if (BurnsAmount <= 0)
        {
            BurnsAmount = 0;
        }

        if (OxygenAmount >= 1)
        {
            OxygenAmount = 1;
        }
    }
}
