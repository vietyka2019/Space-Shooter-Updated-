using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public GameObject other; 
    Enemy enemy;

    private void Start()
    {
        enemy = new Enemy(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDmg(int damage)
    {
        health -= damage;
        Debug.Log($"current health: {health}");
        if (health <= 0)
        {
            health = 0;
        }
    }
}
