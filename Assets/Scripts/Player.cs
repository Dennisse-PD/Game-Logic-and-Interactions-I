using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //cast the ray when mouse left button is pressed
            castRay();
        }
    }
    void castRay()
    {
        //Raycast Parameter Variables
        RaycastHit hitInfo; //what was hit? This variabel stores the answer

        //origin variable using camera position to cast ray from the mouse click position by using read value from new input system
        Ray rayOrigin = GetComponent<Camera>().ScreenPointToRay(Mouse.current.position.ReadValue()); 

        if(Physics.Raycast(rayOrigin, out hitInfo)) //Casts ray from origin, then check what was hit
        {
            var hitObject = hitInfo.collider;//variable to store collider data acquired via
            var hitRenderer = hitInfo.collider.GetComponent<Renderer>();

            if (hitObject == null)
            {
                return; // switch case won't run if there is nothing there(null)
            }
            switch (hitInfo.collider.tag)
            {
                case "Player":
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.green);
                    hitRenderer.material.color = UnityEngine.Random.ColorHSV();

                    break;
                case "Enemy":
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.red);
                    hitRenderer.material.color = Color.red;
                    break;
            }
        }
        else
        {
            //if there is not object intercepted by the ray this happens
            Debug.Log("Nothing to hit here...");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.gray);
        }
    }
}
