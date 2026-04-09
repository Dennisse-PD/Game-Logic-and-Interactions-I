using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet_holes : MonoBehaviour
{
    [SerializeField] 
    private GameObject _bulletHolePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Instantiate(_bulletHolePrefab, hitInfo.point + -transform.forward, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }
}

