using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Raycast_Color : MonoBehaviour
{
    [SerializeField] GameObject _cube;
    [SerializeField] LayerMask _rayMask;

    private void Update()
    {

        //if mouse click 
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse click registered!");
            //fire cast from cam
            castRay();
        }


    }
    private void castRay()
    {
        //fire cast from cam
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out RaycastHit hitinfo, 100, _rayMask))
        //transform.position = origin , transform.vecttor 3 the direction of rht ray, out is the output variable which is of type Raycasthit, 20 is the units it travelels

        {
            Debug.Log("Hit something!");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.green);
            _cube.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            Debug.Log("Hit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.red);
        }
        
        }
    }
