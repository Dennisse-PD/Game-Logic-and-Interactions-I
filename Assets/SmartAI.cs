using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class SmartAI : MonoBehaviour
{
    //Enum to control enemy AI behavior 
    private enum AIState
    {
        Walking,
        Jumping,
        Attacking,
        Death

    }
    //Global Vriables
    //Patrol movement
    [SerializeField] private List<Transform> _wayPoints;
    private NavMeshAgent _agent;
    private int _currentPoint = 0;

    //Enum Variables
    [SerializeField] private AIState _currentState;
    private bool _isAttacking = false; //for coroutine 

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
        //Jump when E key is pressed
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            //change AI state here, execute the jump function in the switch statement 
            _currentState = AIState.Jumping;
            _agent.isStopped = true; //to stop the agen, it stops moving on its oww but doesn't mean its not running
        }

        //Enum switch statement
        switch (_currentState)
        {
            case AIState.Walking:
                Debug.Log("Walking...");
                PatrolCycle();
                StopCoroutine(AttackRoutine());
                break;
            case AIState.Jumping:
                //jump function exceuters here
                Jump();
                break;
            case AIState.Attacking:
                //Start coroutine here
               if(_isAttacking == false)
                {
                    Debug.Log("Attacking");
                    StartCoroutine(AttackRoutine());
                    _isAttacking = true;
                }
                break;
            case AIState.Death:
                Debug.Log("Dying...");
                break;
        }
    }
    private void PatrolCycle()
        {
        // Returns if no points have been set up
        if (_wayPoints.Count == 0)
            return;
        if (_agent.remainingDistance < 0.5f)
        {
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
            //change current state to attacking 
            _currentState = AIState.Attacking;


        }
           
    }
    private void Jump()
    {
        Debug.Log("Congrats...you are jumping");
    }

    //This corourinte is to stop the enemy from moving, attack, then resume patrol. Call from switch case!
    IEnumerator AttackRoutine()
    {
        //Stop movement
        _agent.isStopped = true;

        // Wait 3 seconds
        yield return new WaitForSeconds(3.0f);

        // Resume movement
        _agent.isStopped = false;
        _currentState = AIState.Walking;
        _isAttacking = false;
    }
}
    //only increment if the number is less than the list lengh
    //when it reaches list lengh, reverse the order so instead of ++ do -- 

