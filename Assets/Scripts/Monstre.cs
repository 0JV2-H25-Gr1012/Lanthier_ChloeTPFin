using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monstre : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _cible;

    // Wander parameters
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;
    private float _wanderTimer;
    private bool _isWandering = false;

    public int roomAreaIndex = 3;  // Your room area index

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _cible = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found! Make sure the player is tagged as 'Player'.");
        }

        _wanderTimer = wanderInterval;
    }

    void Update()
    {
        if (_cible == null)
            return;

        int playerAreaMask = GetNavMeshAreaAtPosition(_cible.position);

        if (playerAreaMask == (1 << roomAreaIndex))
        {
            if (!_isWandering)
            {
                Debug.Log("Player entered room area. Enemy starts wandering.");
                _isWandering = true;
                _wanderTimer = 0f; // immediately pick a wander destination
            }

            _wanderTimer -= Time.deltaTime;
            if (_wanderTimer <= 0f)
            {
                Wander();
                _wanderTimer = wanderInterval;
            }
        }
        else
        {
            if (_isWandering)
            {
                Debug.Log("Player left room area. Enemy resumes chasing.");
                _isWandering = false;
            }
            _agent.SetDestination(_cible.position);
        }
    }

    void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randomDirection, out navHit, wanderRadius, NavMesh.AllAreas))
        {
            _agent.SetDestination(navHit.position);
        }
    }

    int GetNavMeshAreaAtPosition(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 1.0f, NavMesh.AllAreas))
        {
            return hit.mask;
        }
        return -1;
    }
}