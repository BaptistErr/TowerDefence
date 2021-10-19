using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    //public AudioSource sonBoulet;
    //public AudioSource sonHitEnnemi;
    [SerializeField]
    private float force;

    public int damage;

    private float initializationTime;

    [SerializeField]
    private GameObject impactParticle;

   
    void Start()
    {
        //sonBoulet = GetComponent<AudioSource>();
        //sonHitEnnemi = GetComponent<AudioSource>();

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
                //sonBoulet.PlayClipAtPoint(sonHitEnnemi, other.transform.position, float volume = 1.0F);
                other.GetComponent<Ennemi>().GetDamage(damage);
            }

            impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, Vector3.zero)) as GameObject;
            //sonBoulet.PlayClipAtPoint(sonBoulet, Vector3 position, float volume = 1.0F);
            Destroy(impactParticle, 3);
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>().Stop();
            transform.GetChild(0).GetChild(1).GetComponent<ParticleSystem>().Stop();
        }
    }
}
