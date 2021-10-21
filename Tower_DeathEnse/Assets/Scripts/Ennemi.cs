using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    GameManager gameManager;
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

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        objective = GameObject.Find("Objective");
        target = objective.transform;
        destination = target.transform.position;

        if(FindObjectOfType<GameManager>().level == 0)
        {
            destination += new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-4.6f, 4.6f));
        }
        else
        {
            destination += new Vector3(Random.Range(-4.6f, 4.6f), 0, Random.Range(-0.5f, 0.5f));
        }
        agent.SetDestination(destination);
    }
    private void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude); 
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
            if (!dead)
            {
                gameManager.ennemiMort += 1;
                gameManager.SetMoney(10);
                agent.isStopped = true;
                anim.SetTrigger("Death");
                dead = true;
            }
            Destroy(gameObject, 2);
           
        }
    }

   

    public IEnumerator Attack(float waittime)
    {
        while (true)
        {
            anim.SetBool("Attacks", true);
            if (target)
            {
                target.GetComponentInParent<ObjectiveBehaviour>().GetDamage(damage);
            }
            else
            {
                StopCoroutine(attack);
                anim.SetBool("Attacks", false);
            }

            yield return new WaitForSeconds(rate);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Objective") && agent.remainingDistance < 3)
        {
            attack = StartCoroutine(Attack(rate));
        }
    }



}