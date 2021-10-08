using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public GameObject bullet;

    public int BulletDamage;

    public Vector3 target;

    public Transform cannon;

    private Transform cannonGraphic;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cannonGraphic = cannon.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            target = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
            cannon.LookAt(target);
            StartCoroutine(Shoot());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            target = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
            cannon.LookAt(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            Instantiate(bullet, cannonGraphic.position, cannonGraphic.rotation);
            yield return new WaitForSeconds(1f);
        }
    }
}
