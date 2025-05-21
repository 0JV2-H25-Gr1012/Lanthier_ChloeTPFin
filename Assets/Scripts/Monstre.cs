using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monstre : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _cible;

    
    public float wanderRadius = 10f;
    public float wanderInterval = 3f;
    private float _wanderTimer;
    private bool _isWandering = false;

    public int roomAreaIndex = 3;

    
    public float damageCooldown = 1.0f;
    private float lastDamageTime = -999f;

    
    public float damageStartDelay = 1.0f;
    private float _spawnTime;

    
    public float respawnDelay = 3.0f;
    private Vector3 _spawnPosition;
    private Collider _collider;
    private Renderer[] _renderers;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<Collider>();
        _renderers = GetComponentsInChildren<Renderer>();
        _spawnPosition = transform.position;

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
        _spawnTime = Time.time;
    }

    void Update()
    {
        if (_cible == null || !_agent.enabled)
            return;

        int playerAreaMask = GetNavMeshAreaAtPosition(_cible.position);

        if (playerAreaMask == (1 << roomAreaIndex))
        {
            if (!_isWandering)
            {
                Debug.Log("Player entered room area. Enemy starts wandering.");
                _isWandering = true;
                _wanderTimer = 0f;
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

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit navHit, wanderRadius, NavMesh.AllAreas))
        {
            _agent.SetDestination(navHit.position);
        }
    }

    int GetNavMeshAreaAtPosition(Vector3 position)
    {
        if (NavMesh.SamplePosition(position, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            return hit.mask;
        }
        return -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (Time.time - _spawnTime < damageStartDelay)
            {
                Debug.Log("Damage ignored due to spawn delay.");
                return;
            }

            Debug.Log("Enemy collided with Player.");

            if (Time.time - lastDamageTime > damageCooldown)
            {
                LivesManager livesManager = FindObjectOfType<LivesManager>();
                if (livesManager != null)
                {
                    Debug.Log("Player hit! Losing a life.");
                    livesManager.LoseLife();
                    lastDamageTime = Time.time;

                    StartCoroutine(Respawn());
                }
                else
                {
                    Debug.LogWarning("LivesManager not found in scene.");
                }
            }
            else
            {
                Debug.Log("Damage cooldown active. No life lost.");
            }
        }
    }

    IEnumerator Respawn()
    {
        // Hide enemy
        _agent.enabled = false;
        _collider.enabled = false;
        foreach (var r in _renderers)
            r.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        // Reset position
        transform.position = _spawnPosition;

        // Reactivate visuals and movement
        foreach (var r in _renderers)
            r.enabled = true;
        _agent.enabled = true;

        // Wait briefly before enabling collider to avoid instant damage
        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;

        // Reset spawn time for delay-based damage protection
        _spawnTime = Time.time;
    }
}
