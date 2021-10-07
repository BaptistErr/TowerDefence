using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class SpawnEnnemi : MonoBehaviour
{
    public Transform target;
    public GameObject Spawnee;
    public NavMeshAgent agent;
    public bool StopSpawn = false;
    public float tpsSpawn;
    public float delaiSpawn;
    
    void Start()
    {
        agent.SetDestination(target.transform.position);
        InvokeRepeating("SpawnObjet", tpsSpawn, delaiSpawn);
    }
    public void SpawnObjet()
    {
        Instantiate(Spawnee, transform.position, transform.rotation);
        if (StopSpawn)
        {
            CancelInvoke("SpawnObjet");
        }
    }
    

}
