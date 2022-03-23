using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class WaypointMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3[] _waypoints;
    private float _walkingArenaRadius = 40f;
    private int _pointsCount = 15;
    private int _target;
    private RaycastHit _hit;
    private float _maxDistance = 10f;
    private int _layerMask = 3;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _waypoints = new Vector3[_pointsCount];

        for (int i = 0; i < _waypoints.Length; i++)
        {
            float pointXPosition = Random.Range(-_walkingArenaRadius, _walkingArenaRadius);
            float pointZPosition = Random.Range(-_walkingArenaRadius, _walkingArenaRadius);
            _waypoints[i] = new Vector3(pointXPosition, 0, pointZPosition);
        }
    }

    private void Update()
    {
        if (_agent.transform.position==_agent.pathEndPosition)
        {
            TargetUpdate();
        }

        _agent.SetDestination(_waypoints[_target]);

        if(Physics.Raycast(_agent.transform.position, _waypoints[_target], _maxDistance, _layerMask))
        {
            TargetUpdate();
        }
    }

    private void TargetUpdate()
    {
        _target = Random.Range(0, _pointsCount);
    }

}
