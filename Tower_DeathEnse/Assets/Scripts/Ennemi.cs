using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    GameObject objective;
    private Coroutine attack;
    //caracteristique de l'ennemi

    public int health;

    private int defaultHealth;

    public int damage;
    


    [SerializeField]
    private float rate;

    public bool dead = false;

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
       

        
        anim = FindObjectOfType<Animator>();
        objective = GameObject.Find("Objective");
        target = objective?.transform;
        destination = target.transform.position;
        destination += new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-4.6f, 4.6f));
        agent.SetDestination(destination);
    }
    private void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        if (!objective)
        {
            StopCoroutine(attack);
            anim?.SetBool("Attacks", false);
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
                anim?.SetBool("Attacks", false);
            }
            if (!dead)
            {
                agent.isStopped = true;
                anim?.SetTrigger("Death");
                dead = true;
            }
            
            Destroy(gameObject, 2);
           
        }
    }

   

    public IEnumerator Attack(float waitTime)
    {
        while (true)
        {
            anim?.SetBool("Attacks", true);
            if (objective)
            {
                target?.parent?.GetComponent<ObjectiveBehaviour>()?.GetDamage(damage);
            }
            else
            {
                anim?.SetBool("Attacks", false);
                StopCoroutine(attack);
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Objective") && agent.remainingDistance < 3)
        {
            agent.isStopped = true;
            attack = StartCoroutine(Attack(rate));
        }
    }



}