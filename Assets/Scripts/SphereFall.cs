using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, -Vector3.up * 1f, out hitInfo))
        {
            Debug.Log("Hit something");
            float distanceToHit = hitInfo.distance; // This is the distance
            Debug.Log("Distance: " + distanceToHit);
            if (distanceToHit < 1f)
            {
                Debug.Log("You ran out of distance");
                rb.isKinematic = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, -Vector3.up * 1f);
    }
    //when the sphere hits the floor, is kinematic should be switch on, need to measure this via raycast
}

