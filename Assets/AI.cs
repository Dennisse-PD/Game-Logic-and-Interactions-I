using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    // Store all points, object array?
   [SerializeField] private Transform[] _points;

    // Select a random waypoint
    private int _destinationPoint;

    // Access the object with the nav mesh agent
    [SerializeField] private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        //check if nav mesh agent is available to avoid runtime errors
        if (_agent == null)
        {
            Debug.LogError("Nav mesh agent is null!");
        }
        //Look for our nav mesh
        //_agent = GetComponent<NavMeshAgent>();

        //Disables auto-breaking for continous movement between points
        _agent.autoBraking = false;

        //assingin values
        //_destinationPoint = Random.Range(0, _points.Length);

        //call function to move to next random point
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
    private void GotoNextPoint()
    {    

        _destinationPoint = Random.Range(0, _points.Length);

        //set the agent to go to the next position, randomied by assigning it before ^
      _agent.destination =  _points[_destinationPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        _destinationPoint = (_destinationPoint + 1) % Random.Range(0, _points.Length);
    }

}
