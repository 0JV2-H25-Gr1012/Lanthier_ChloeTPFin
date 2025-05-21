using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        float speed = _agent.velocity.magnitude;
        _animator.SetFloat("Speed", speed); 
    }
}
