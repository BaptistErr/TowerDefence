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

    [SerializeField]
    private GameObject impactParticle;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.Impulse);
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        LayerMask layer = other.transform.gameObject.layer;
        if (layer != LayerMask.NameToLayer("Tower") && layer != LayerMask.NameToLayer("Upgrade") && layer != LayerMask.NameToLayer("Objective") && other.GetComponent<BulletBehaviour>() == null)
        {
            if(layer == LayerMask.NameToLayer("Enemy"))
            {
                other.GetComponent<Ennemi>().GetDamage(damage);
            }

            impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, Vector3.zero)) as GameObject;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>().Stop();
            transform.GetChild(0).GetChild(1).GetComponent<ParticleSystem>().Stop();
        }
    }
}
