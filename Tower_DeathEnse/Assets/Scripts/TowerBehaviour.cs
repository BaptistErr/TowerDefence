using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public GameObject bullet;

    public int BulletDamage;

    public float speed;

    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        target = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        StartCoroutine(Shoot(target));
    }

    private void OnTriggerStay(Collider other)
    {
        target = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
        transform.parent.parent.GetChild(0).LookAt(target);
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(Shoot(target));
    }

    IEnumerator Shoot(Vector3 target)
    {
        while (true)
        {
            GameObject instantiated = Instantiate(bullet, transform.position, transform.rotation);
            instantiated.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return new WaitForSeconds(1f);
        }
    }
}
