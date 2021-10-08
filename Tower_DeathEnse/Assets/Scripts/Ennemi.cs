using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    //caracteristique de l'ennemi

    public int health;
    public int damage;
    //---------------------------

    //mouvement de l'ennemi

    public Transform Target;
    public NavMeshAgent agent;

    private void Start()
    {
       
        agent.SetDestination(Target.transform.position);
    }
    //-----------------------------

    //methodes de l'ennemi
    private void DealDamage()
    {

    }

    public void GetDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}