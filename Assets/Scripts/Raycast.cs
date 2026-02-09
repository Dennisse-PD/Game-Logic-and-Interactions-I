using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    [SerializeField] LayerMask _rayMask;

    private void Update()
    {

        //if mouse click 
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //fire ray from cam
            castRay();
        }


    }
    private void castRay()
    {
        //mouse position vector variable
        Vector2 mousePos = Mouse.current.position.ReadValue();// stores the current mouse position

        //fire cast from cam
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);//The proper way to fire from screen

        //store the hit information, what did it hit?
        RaycastHit hitInfo;

        //Check if the ray hit something
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            var hitObject = hitInfo.collider;//var to store collider acquired via hitinfo
            if (hitObject.GetComponent<MeshRenderer>() != null) //always check if not null 
            {

                Debug.Log("Hit Player Collider: " + hitInfo.collider.name);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.green);
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
            }

            else
            {
                Debug.Log("Hit wrong Collider: " + hitInfo.collider.name);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.red);


            }
        }

        else
        {
            Debug.LogError("Missing Component!");
        }


        }
    }

