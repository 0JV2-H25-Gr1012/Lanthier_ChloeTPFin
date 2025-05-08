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

    }

    // Update is called once per frame
    void Update()
    {
        BougerAgent();
    }

    void BougerAgent(){

        _agent.SetDestination(_cible.position);

    }
}
