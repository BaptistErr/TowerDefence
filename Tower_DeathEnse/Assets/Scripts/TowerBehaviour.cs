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

    private bool shooting = false;
    private Coroutine shoot;

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
        else if (targets.Count != 0)
        {
            targets.RemoveAt(0);
            target = targets[0];
        }
        else if (shooting)
        {
            StopCoroutine(shoot);
            shooting = false;
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
                cannon.LookAt(target.transform.position);
                shoot = StartCoroutine(Shoot());
                shooting = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other);
        if (other == target)
        {
            target = null;
            if(targets.Count != 0)
            {
                target = targets[0];
            }
            else
            {
                StopCoroutine(shoot);
                shooting = false;
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
    public static Vector3 CalculateInterceptCourse(Vector3 aTargetPos, Vector3 aTargetSpeed, Vector3 aInterceptorPos, float aInterceptorSpeed)
    {
        Vector3 targetDir = aTargetPos - aInterceptorPos;
        float iSpeed2 = aInterceptorSpeed * aInterceptorSpeed;
        float tSpeed2 = aTargetSpeed.sqrMagnitude;
        float fDot1 = Vector3.Dot(targetDir, aTargetSpeed);
        float targetDist2 = targetDir.sqrMagnitude;
        float d = (fDot1 * fDot1) - targetDist2 * (tSpeed2 - iSpeed2);
        if (d < 0.1f)  // negative == no possible course because the interceptor isn't fast enough
            return Vector3.zero;
        float sqrt = Mathf.Sqrt(d);
        float S1 = (-fDot1 - sqrt) / targetDist2;
        float S2 = (-fDot1 + sqrt) / targetDist2;
        if (S1 < 0.0001f)
        {
            if (S2 < 0.0001f)
                return Vector3.zero;
            else
                return (S2) * targetDir + aTargetSpeed;
        }
        else if (S2 < 0.0001f)
            return (S1) * targetDir + aTargetSpeed;
        else if (S1 < S2)
            return (S2) * targetDir + aTargetSpeed;
        else
            return (S1) * targetDir + aTargetSpeed;
    }
}
