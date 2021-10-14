using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    private GameObject objective;

    //caracteristique de l'ennemi

    public int health;

    private int defaultHealth;

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
        defaultHealth = health;
        anim = GetComponent<Animator>();
        objective = GameObject.Find("Objective");

        if (target)
        {
            destination = target.transform.position + new Vector3(Random.insideUnitSphere.x * 5, 0, Random.insideUnitSphere.z * 1.5f);
            agent.SetDestination(destination);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Objective") && agent.remainingDistance < 3)
        {
            attack = StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            //anim.SetBool("Attacks", true);
            //anim.Play("Attacks");
            if (target)
            {
                target.parent.GetComponent<ObjectiveBehaviour>().GetDamage(damage);
            }
            else
            {
                StopCoroutine(attack);
            }
            yield return new WaitForSeconds(rate);
        }
    }
}