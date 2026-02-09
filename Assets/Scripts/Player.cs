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
            var hitObject = hitInfo.collider;//variable to store collider data acquired via hitinfo
            if (hitObject.GetComponent<MeshRenderer>() != null)  //always check if there is a collider at all to avoid code-breaking errors
            {
                if (hitInfo.collider.tag == "Player")
                    Debug.Log("You just hit " + hitInfo.collider.name);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.green);
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
            }
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.black;
            }
        }
        else
        {
            //if there is not object intercepted by the ray this happens
            Debug.Log("Nothing to hit here...");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.red);
        }
    }
}
