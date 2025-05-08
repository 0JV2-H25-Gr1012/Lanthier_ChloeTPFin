using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monstre : MonoBehaviour
{
    
    private NavMeshAgent _agent;
    [SerializeField] private Transform _cible;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _agent.SetDestination(_cible.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
