using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMovementBehavior : Behavior
{
    private PathFinding path;
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        path = GetComponent<PathFinding>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (BehaviorActive)
       {
            if(manager.distance <= settings.stoppingDistance)
            {
                
                isSatisfied = true;
                Satisfied(satisfied);
            }
            if (manager.distance >= settings.stoppingDistance)
            {
                isSatisfied = false;
                rb.velocity += path.movementspeed * speed;
                Unsatisfied(unsatisfied);
            }
            
        }


    }


}
