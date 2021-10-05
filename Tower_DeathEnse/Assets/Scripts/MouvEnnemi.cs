using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvEnnemi : MonoBehaviour
{
    public float Speed;
    public Transform Target;
    public NavMeshAgent Ennemi;

    private void Start()
    {
        Ennemi.SetDestination(Target.transform.position);
    }


}