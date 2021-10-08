using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.Impulse);
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.layer != LayerMask.NameToLayer("Friendly"))
        {
            Debug.Log(other.name);
            Destroy(transform.gameObject);
        }
    }
}
