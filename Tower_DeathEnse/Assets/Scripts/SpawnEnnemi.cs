using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemi : MonoBehaviour
{
    public GameObject Spawnee;
    public bool StopSpawn = false;
    public float tpsSpawn;
    public float delaiSpawn;
    void Start()
    {
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
