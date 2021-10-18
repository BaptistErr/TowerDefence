using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float force;

    public int damage;

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
        if (layer != LayerMask.NameToLayer("Tower") && other.GetComponent<BulletBehaviour>() == null)
        {
            other.GetComponent<Ennemi>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
