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

    //object gameManager
    GameManager gameManager;


    //d�claration des vagues d'�nnemis    
    private int MaxParVague =2;
    private int nbvague;
    //compteurs d'ennemi
    private int NbGlobalEnnemi = 0; // global
    private int nbEnnemiVague; // par vague
    int compteurVague = 0; 

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        nbvague = gameManager.nbMaxEnnemi / MaxParVague;
        jeux();
    }
    public void jeux()
    {
        //commencer les vagues avec 5 secondes entre chaque vagues
        StartCoroutine(ReguVague(5));

        // fct qui appelle reguVague qui appelle ensuite wave qui finit par appeler spawnObject 
    }

    //fct -> r�guler les vagues 
    public IEnumerator ReguVague(float TpsEntreVague)
    {
        while (true)
        {
            if (compteurVague <= nbvague)
            {
                compteurVague += 1;
                Wave(10, 0, 1);
            }

            yield return new WaitForSeconds(TpsEntreVague);
        }
    }
    //fct -> lancer les vagues d'ennemis 
    public void Wave(int vitesseennemi, int TpsSpawn, int DelaySpawn)

    {
        agent.speed = vitesseennemi;
        InvokeRepeating("SpawnObjet", TpsSpawn, DelaySpawn);
    }

    //fct -> g�re le nbr d'ennemis global
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
            
            if (NbGlobalEnnemi < gameManager.nbMaxEnnemi)
            {
                nbEnnemiVague = 0;
            }
            
                //arreter la coroutine 
                StopCoroutine(ReguVague(5));
                CancelInvoke("SpawnObjet");
            
        }
    }


    
    
}
