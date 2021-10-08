using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float force;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.Impulse);
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        LayerMask layer = other.transform.gameObject.layer;
        if (layer != LayerMask.NameToLayer("Friendly"))
        {
            if (layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.Log(damage);
                other.GetComponent<Ennemi>().GetDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
