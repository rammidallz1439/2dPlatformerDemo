using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health = 50;
    public float d_Health = 0.2f;
    public  bool canAttck;
    public void DecreaseHealth(float damage)
    {
        health -= damage;
    }
    public void IncreaHealth(int increase)
    {
        health+= increase;
    }
}
