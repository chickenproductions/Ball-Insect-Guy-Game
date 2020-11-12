using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct BehaviorModeStruct
{
    public bool EveryInterval;
    public bool Once;
}


public class Behavior : MonoBehaviour
{  
    public BehaviorModeStruct BehaviorMode;

    public EnemyBehaviorManager manager;
    public BehaviorSettings settings;
    [Tooltip("Call using Script, useful for just generic static intervals")]
    public float GenericInterval = 0.5f;
    public float interval =0.5f;
    public bool BehaviorActive = false;

    public UnityEvent ConditionSatisfied;
    public UnityEvent ConditionUnSatisfied;
    
    public bool isSatisfied;
    public bool satisfied = true;
    public bool unsatisfied = false;

    public void StopBehavior()
    {
        if (BehaviorMode.EveryInterval)
        {
            CancelInvoke();
        }
        BehaviorActive = false;
    }
    public void StartBehavior()
    {
        if (BehaviorMode.EveryInterval)
        {
            Repeating();
        }
        BehaviorActive = true;
    }
    
    public void Repeating()
    {
        InvokeRepeating("EveryInterval", 0, interval);
    }

    public void EveryInterval()
    {
    }

    public void DoOnce()
    {
        Debug.Log("did Once on conditionMet");
    }

    public void Satisfied(bool satisfy)
    {
        if (satisfy)
        {
        ConditionSatisfied.Invoke();
        satisfied = false;
        unsatisfied = true;
        }
        else
        {
            return;
        }
       
    }
    public void Unsatisfied(bool satisfy)
    {
        if (satisfy)
        {
        ConditionUnSatisfied.Invoke();
        satisfied = true;
        unsatisfied = false;
        }
        else
        {
            return;
        }
      
    }
}
