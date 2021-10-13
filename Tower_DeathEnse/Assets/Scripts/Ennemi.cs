using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    private GameObject objective;

    //caracteristique de l'ennemi

    public int health;
    public int damage;

    private Coroutine attack;

    [SerializeField]
    private float rate;

    //---------------------------

    //mouvement de l'ennemi

    public Transform target;
    public NavMeshAgent agent;

    private Vector3 destination;

    private float dist;

    //animator de l'ennemi 
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        objective = GameObject.Find("Objective");

        destination = target.transform.position + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-2.5f, 10f));
        agent.SetDestination(destination);
    }

    private void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            if (attack == null)
            {
                attack = StartCoroutine(Attack());
            }
        }
    }

    //-----------------------------

    //methodes de l'ennemi
    public void GetDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(attack != null)
            {
                StopCoroutine(attack);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(rate);
        }
    }
}