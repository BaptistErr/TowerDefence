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

    //classe game manager
    


    //déclaration des vagues d'énnemis
    public bool StopSpawn = false;
    private int nbEnnemiVague ;
    private int MaxParVague =3;
    private int nbMaxennemi;
    private int NbGlobalEnnemi = 0;
    int NbVague = 0;

    void Start()
    {
        nbMaxennemi = 14;
       

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
        
        NbGlobalEnnemi += 1;
        if (nbEnnemiVague < MaxParVague)
        {
            nbEnnemiVague += 1;
            Instantiate(Spawnee, transform.position, transform.rotation);
            Spawnee.GetComponent<Ennemi>().target = target;
        }
        else
        {
            
            if (NbGlobalEnnemi < nbMaxennemi)
            {
                nbEnnemiVague = 0;
            }
            
                //arreter la coroutine 
                StopCoroutine(ReguVague(5));
                CancelInvoke("SpawnObjet");
            
        }
    }

    //fct -> réguler les vagues 
    public IEnumerator ReguVague(float TpsEntreVague)
    {
        while (true)
        {
            if(NbVague<=6)
            {
                NbVague += 1;
                Wave(2, 2, 2);
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
