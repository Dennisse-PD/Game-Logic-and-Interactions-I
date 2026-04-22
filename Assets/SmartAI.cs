using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmartAI : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints;
    private NavMeshAgent _agent;
    private int _currentPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.autoBraking = true;

        if( _agent != null )
        {
            _agent.destination = _wayPoints[_currentPoint].position;
        }
        PatrolCycle();
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance < 0.5f)
            PatrolCycle();
    }
    private void PatrolCycle()
        {
        // Returns if no points have been set up
        if (_wayPoints.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        _agent.destination = _wayPoints[_currentPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        //  _currentPoint = (_currentPoint.   + 1) % _wayPoints.Count;

        _currentPoint++;
        if (_currentPoint >= _wayPoints.Count)
        {
            _wayPoints.Reverse(0, _wayPoints.Count);
            _currentPoint = 0;
        }
    }
    //only increment if the number is less than the list lengh
    //when it reaches list lengh, reverse the order so instead of ++ do -- 
}
