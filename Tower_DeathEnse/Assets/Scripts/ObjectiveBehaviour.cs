using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBehaviour : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    private int health;

    public void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    public void GetDamage(int damage)
    {
        
        gameManager.vieobjectif -= damage;
        health = gameManager.vieobjectif;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
