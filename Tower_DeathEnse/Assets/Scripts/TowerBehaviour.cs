using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    public int BulletDamage;

    private Collider target;

    [SerializeField]
    private Transform cannon;

    [SerializeField]
    private int defaultDamage;

    private Transform cannonGraphic;

    public int level = 1;

    private List<Collider> targets = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        cannonGraphic = cannon.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            cannon.LookAt(target.transform);
        }
        else if (targets.Count > 0)
        {
            targets.RemoveAt(0);
            target = targets[0];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            targets.Add(other);
            if (!target)
            {
                target = targets[0];
                cannon.LookAt(target.transform);
                StartCoroutine(Shoot());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other);
        if (other == target)
        {
            if(targets.Count != 0)
            {
                target = targets[0];
            }
            else
            {
                StopCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            Instantiate(bullet, cannonGraphic.position, cannonGraphic.rotation);
            bullet.GetComponent<BulletBehaviour>().damage = defaultDamage * level;
            bullet.GetComponent<BulletBehaviour>().parentLayer = gameObject.layer;
            yield return new WaitForSeconds(1f);
        }
    }
}
