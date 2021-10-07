using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("yo");
        Vector3 target = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        transform.LookAt(target);
        InvokeRepeating("Shoot", 0, 0);
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
