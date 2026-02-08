using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Raycast_Color : MonoBehaviour
{
    [SerializeField] GameObject _cube;
    /*  [[[[[[[[GENERAL INFO]]]]]]]]*/
    //Requires user input
    //Resgister left-mouse click

    //if click is registered
    //Cast ray from main cam or mouse position
    //Change color when ray hits cube obj(acces the obj we hit)
    //Filtering with layermask is optinal in this case but I might do it anyways because it's cleaner

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
            //search for player layer--> if layer....
            //access the object so get component
            //change component color
        
    }
}
