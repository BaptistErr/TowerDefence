using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBehaviour : MonoBehaviour
{
    GameManager gameManager;

    public HealthBase lvlui;
    
    [SerializeField]
    private int health;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lvlui = GameObject.Find("BaseHealthBar").GetComponent<HealthBase>();
        lvlui.SetMaxHealth(gameManager.vieobjectif);

    }

    public void GetDamage(int damage)
    {
       
        gameManager.vieobjectif -= damage;
        health = gameManager.vieobjectif;

        lvlui.SetHealth(health);
        Debug.Log("vie Objectif: " + health);


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
