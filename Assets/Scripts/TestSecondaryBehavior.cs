using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSecondaryBehavior : Behavior
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        interval = GenericInterval;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    new void EveryInterval()
    {
        //Debug.Log("it works!");
        rb.AddForce( new Vector2(0, 900));
    }
}
