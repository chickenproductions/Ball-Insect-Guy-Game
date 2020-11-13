using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehaviorManager : MonoBehaviour
{
    public BehaviorSettings settings;
    public UnityEvent aiStop;
    public UnityEvent aiStart;
    bool start;
    bool stop;
    public float distance;
    void Awake()
    {
        start = true;
        stop = false;
    }

    void FixedUpdate()
    {
        distance = Vector2.Distance(GameManger.gamemanager.Player.transform.position, transform.position);
        if(distance <= settings.startDistance)
        {
            AiStart(start);
        }
        else if(distance >= settings.startDistance)
        {
            AiStop(stop);
        }
  

    }
    void AiStart(bool CanStartAgain)
    {
        if (CanStartAgain)
        {
            start = false;
            stop = true;
            aiStart.Invoke();
        }
        else
        {
            return;
        }
        
    }
    void AiStop(bool CanStopAgain)
    {
        if (CanStopAgain)
        {
            start = true;
            stop = false;
            aiStop.Invoke();
        }
        else
        {
            return;
        }
        
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, settings.startDistance);
    }
}
