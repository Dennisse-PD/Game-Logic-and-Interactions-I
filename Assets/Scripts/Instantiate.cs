using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class Instantiate : MonoBehaviour
{
    //variable to instantiate prefab
    [SerializeField] GameObject _capsulePrefab;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //if left click instantiate
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            castRaySphere();
        }
    }
   
    void castRaySphere()
    {
        //hitInfo (to detect the floor)
        RaycastHit hitInfo;

        //raycast origin = mouse position
        Ray rayOrigin = GetComponent<Camera>().ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(rayOrigin, out hitInfo)) //Casts ray from origin, then check what was hit
        {
            var hitObject = hitInfo.collider;//variable to store collider data acquired via

            if (hitObject == null)
            {
                return; // switch case won't run if there is nothing there(null)
            }
            //if the collider isn't null, instantiate the capsule in the mouse/hit position
            Instantiate(_capsulePrefab, hitInfo.point, Quaternion.identity);


        }
        

       

    }


}
