using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class AI : MonoBehaviour
{
    // Store all points, object array?
    [SerializeField] private Transform[] _points;

    // Select a random waypoint, .random on the array?
    private int _destinationPoint = Random.Range(0, _points.Length);

    // Traverse to the random point, how do we do this in nav mesh? Check nav agen documentation 
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        //check if nav mesh agent is available to avoid runtime errors
        if( _agent == null )
        {
            Error.Log("Nav mesh agent is null!");
        }
        //Look for our nav mesh
        _agent = GetComponent<NavMeshAgent>();

        //Disables auto-breaking for continous movement between points
        _agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
