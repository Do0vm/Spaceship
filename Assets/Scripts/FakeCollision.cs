using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCollision : MonoBehaviour
{

    public float radius;
    public FakeCollision trackedObject;

    public GameObject Asteroid;

    private void OnDrawGizmos()
    {
        if(!trackedObject) return;

        Vector3 difference = (trackedObject.transform.position - transform.position);
        float squareDistance = (difference.x * difference.x) + (difference.y * difference.y) + (difference.z * difference.z);
       
        if (squareDistance < (radius + trackedObject.radius) * (radius + trackedObject.radius))

        {
            Gizmos.color = Color.red;
        }




        else {

                Gizmos.color = Color.yellow;
        }
        
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
