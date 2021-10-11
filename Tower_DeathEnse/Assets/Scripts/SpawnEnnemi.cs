using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SpawnEnnemi : MonoBehaviour
{
    //déclaration du NavMesh
    public Transform target;
    public GameObject Spawnee;
    public NavMeshAgent agent;

    //déclaration des vagues d'énnemis
    public bool StopSpawn = false;
    private int nombreEnnemi ;
    private int nombreMax =5;

    void Start()
    {
        //agent.SetDestination(target.transform.position);
        jeux();
    }


    //fct -> lancer les vagues d'ennemis 
    public void Wave(int vitesseennemi, int TpsSpawn, int DelaySpawn)

    {
        agent.speed = vitesseennemi;
        InvokeRepeating("SpawnObjet", TpsSpawn, DelaySpawn);
    }
    //fct -> gère le nbr d'ennemis 
    public void SpawnObjet()
    {
        if ( nombreEnnemi < nombreMax)
        {
            nombreEnnemi += 1;
            Instantiate(Spawnee, transform.position, transform.rotation);
            Spawnee.GetComponent<Ennemi>().target = target;

        }
        else
        {
            nombreEnnemi = 0;
            nombreMax += 2;
            CancelInvoke("SpawnObjet");
           
        }
    }

    //fct -> réguler les vagues 
    public IEnumerator ReguVague(float TpsEntreVague)
    {
        while (true)
        {
            Wave(2, 2, 2);
            yield return new WaitForSeconds(TpsEntreVague);
        }
    }

    
    public void jeux()
    {
        //commencer la coroutine 
        StartCoroutine(ReguVague(5));
       //arreter la coroutine a changer d'endroit
        StopCoroutine(ReguVague(5));
    }
}
