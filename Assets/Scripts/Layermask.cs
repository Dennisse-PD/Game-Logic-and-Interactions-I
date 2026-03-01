using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Layermask : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
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
            //raycast origin = mouse position
            Ray rayOrigin = GetComponent<Camera>().ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity, 1 << 7)) //Casts ray from origin, then check what was hi
            {
                Debug.Log("Hit " + hitInfo.collider.name);
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.red;    

            }
        }
    }
   

}


