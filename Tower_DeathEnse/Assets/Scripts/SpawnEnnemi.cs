using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SpawnEnnemi : MonoBehaviour
{
    //d�claration du NavMesh
    public Transform target;
    public GameObject Spawnee;
    public NavMeshAgent agent;

    //d�claration des vagues d'�nnemis
    public bool StopSpawn = false;
    private int nbEnnemiVague ;
    private int MaxParVague =7;
    private int NbMaxEnnemi = 14;
    private int NbGlobalEnnemi = 0;
    int NbVague = 0;

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
    //fct -> g�re le nbr d'ennemis 
    public void SpawnObjet()
    {
        NbGlobalEnnemi += 1;
        if (nbEnnemiVague < MaxParVague)
        {
            nbEnnemiVague += 1;
            Instantiate(Spawnee, transform.position, transform.rotation);
            Spawnee.GetComponent<Ennemi>().target = target;
        }
        else
        {
            if (NbGlobalEnnemi < NbMaxEnnemi)
            {
                nbEnnemiVague = 0;
            }
            //arreter la coroutine 
            StopCoroutine(ReguVague(5));
            CancelInvoke("SpawnObjet");  
        }
    }

    //fct -> r�guler les vagues 
    public IEnumerator ReguVague(float TpsEntreVague)
    {
        while (true)
        {
            if(NbVague<=6)
            {
                NbVague += 1;
                Wave(10, 2, 2);
            }
            
            yield return new WaitForSeconds(TpsEntreVague);
        }
    }

    
    public void jeux()
    {
        //commencer la coroutine 
        StartCoroutine(ReguVague(5));

    }
}
