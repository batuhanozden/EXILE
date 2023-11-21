using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int health = 100;

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }
}
