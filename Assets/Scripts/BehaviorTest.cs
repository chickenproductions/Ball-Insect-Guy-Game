using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTest : Behavior
{
    // Start is called before the first frame update
    void Awake()
    {
        interval = GenericInterval;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    new void EveryInterval()
    {
        Debug.Log("DoesItWork");
    }
}
