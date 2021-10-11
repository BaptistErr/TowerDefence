using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    //caracteristique de l'ennemi

    public int health;
    public int damage;

    [SerializeField]
    private GameObject bullet;
    //---------------------------

    //mouvement de l'ennemi

    public Transform target;
    public NavMeshAgent agent;

    private void Start()
    {
       
        agent.SetDestination(target.transform.position);
    }

    private void Update()
    {
        if(transform.position == target.position)
        {
            StartCoroutine(Shoot());
        }
    }

    //-----------------------------

    //methodes de l'ennemi
    public void GetDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            bullet.GetComponent<BulletBehaviour>().damage = damage;
            bullet.GetComponent<BulletBehaviour>().parentLayer = gameObject.layer;
            yield return new WaitForSeconds(1f);
        }
    }
}