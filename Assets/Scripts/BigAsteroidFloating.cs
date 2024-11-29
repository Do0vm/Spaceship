using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroidFloating : MonoBehaviour
{
    public float moveSpeed = 1f; 
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        
        if (moveDirection == Vector2.zero)
        {
            PickRandomDirection();
        }

        
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    
    void PickRandomDirection()
    {
       
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
