using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour, IMovement
{
    [SerializeField] private float _speed;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        ConfigureAgent();
    }

    public void MoveTo(Vector3 position)
    {
        position.y = transform.position.y;
        _agent.SetDestination(position);
    }

    private void ConfigureAgent()
    {
        _agent.speed = _speed;
    }
}
