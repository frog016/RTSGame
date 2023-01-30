using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _speed;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        ConfigureAgent();
    }

    public void Move(Vector3 position)
    {
        var destination = new Vector3(position.x, transform.position.y, position.z);
        if (_agent.destination == destination)
            return;

        _agent.SetDestination(destination);
    }

    private void ConfigureAgent()
    {
        _agent.speed = _speed;
    }
}