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
    private TowerBehaviour tourelle;

    private void Start()
    {
       
        agent.SetDestination(Target.transform.position);
    }
    //-----------------------------

    //methodes de l'ennemi
    private void DealDamage()
    {

    }
    private bool isDead()
    {
        if (health <= 0)
        {
            return true;
        }
        else return false;
    }
    private void GetDamage()
    {
        if (isDead() is false)
        {
            health -= tourelle.TurretDamage;
        }
    }
}