using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float force;

    public int damage;

    public int parentLayer;

    private float initializationTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.Impulse);
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        LayerMask layer = other.transform.gameObject.layer;
        if (layer.value != parentLayer && other.GetComponent<BulletBehaviour>() == null)
        {
            if (layer == LayerMask.NameToLayer("Enemy"))
            {
                other.GetComponent<Ennemi>().GetDamage(damage);
            }
            else if (layer == LayerMask.NameToLayer("Objective"))
            {
                other.GetComponentInParent<ObjectiveBehaviour>().GetDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
