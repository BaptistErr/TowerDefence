using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    private SphereCollider sphere;

    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 target = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        transform.LookAt(target);
    }
}
