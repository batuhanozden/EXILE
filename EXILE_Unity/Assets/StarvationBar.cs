using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class StarvationBar : MonoBehaviour
{
    private Starvation starvation;

    private float timer = 0;

    [SerializeField] private Player player;

    public void Setup(Starvation starvation)
    {
        this.starvation = starvation;

        starvation.OnStarvationChanged += Starvation_OnStarvationChanged;
    }
    
    private void Starvation_OnStarvationChanged(object sender, EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(starvation.GetStarvationPercent(), 1);
    }

    public void Damage()
    {
        starvation.Damage(5);
    }
    
    public void Heal()
    {
        starvation.Heal(10);
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer % 30 < 0.1f)
        {
            Damage();
        }

        if (ItemSlot.currentUsedItem == "MeatSprite")
        {
            if (Input.GetMouseButtonDown(1))
            {
                Heal();
            }
        }
    }
}
