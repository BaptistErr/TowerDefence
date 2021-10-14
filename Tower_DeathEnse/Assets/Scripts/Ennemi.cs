using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    

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


        //anim = GetComponent<Animator>();
        anim = FindObjectOfType<Animator>();
        
        destination = target.transform.position + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-2.5f, 10f));
        agent.SetDestination(destination);
        
    }

    private void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        
        
        dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)

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
            anim.Play("Die");
            Destroy(gameObject, 1);

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

            anim.SetTrigger("Attacks");

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