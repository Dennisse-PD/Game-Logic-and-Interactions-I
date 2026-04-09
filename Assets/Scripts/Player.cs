using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //Vector 3 to store destination data
   [SerializeField]
   private Vector3 _destination;

    //movement speed
   private float _movementSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       //movement logic, this is done by calculating the distance
       var distance = Vector3.Distance(_destination, transform.position); //this gives us a float value

        if( distance > 0.1f)
        {
            //direction = destination - source (this is the math formula for direction)
            var direction = _destination - transform.position;
            direction.Normalize(); //to avoid extra long vector, this normalizes it to 1

            //movement 
            transform.Translate(direction * _movementSpeed * Time.deltaTime);
        }

    }
    public void UpdatePosition(Vector3 pos)
    {
        _destination = pos; 
    }
}
