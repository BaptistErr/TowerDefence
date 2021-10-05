using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvEnnemi : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent agent;

    private void Start()
    {
        agent.SetDestination(Target.transform.position);
    }


}