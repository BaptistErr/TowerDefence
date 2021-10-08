using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    public int BulletDamage;

    [SerializeField]
    private Vector3 target;

    [SerializeField]
    private Transform cannon;

    [SerializeField]
    private int defaultDamage;

    private Transform cannonGraphic;

    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        cannonGraphic = cannon.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
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
            bullet.GetComponent<BulletBehaviour>().damage = defaultDamage * level;
            yield return new WaitForSeconds(1f);
        }
    }
}
