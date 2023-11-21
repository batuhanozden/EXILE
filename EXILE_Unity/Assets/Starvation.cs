using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starvation : MonoBehaviour
{
    public event EventHandler OnStarvationChanged;
    
    private int starvation;
    private int starvationMax;

    public Starvation(int starvationMax)
    {
        this.starvationMax = starvationMax;
        starvation = starvationMax;
    }

    public int GetHealth()
    {
        return starvation;
    }

    public float GetStarvationPercent()
    {
        return (float) starvation / starvationMax;
    }
    
    public void Damage(int damageAmount)
    {
        starvation -= damageAmount;
        if (starvation < 0) starvation = 0;
        if (OnStarvationChanged != null) OnStarvationChanged(this, EventArgs.Empty);
    }
    
    public void Heal(int healAmount)
    {
        starvation += healAmount;
        if (starvation > starvationMax) starvation = starvationMax;
        if (OnStarvationChanged != null) OnStarvationChanged(this, EventArgs.Empty);
    }
}
