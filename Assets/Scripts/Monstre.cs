using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monstre : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _cible;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        // Automatically find the player by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _cible = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found! Make sure the player is tagged as 'Player'.");
        }
    }

    void Update()
    {
        if (_cible != null)
        {
            _agent.SetDestination(_cible.position);
        }
    }
}
