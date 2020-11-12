using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BehaviorManagerSettings", menuName = "Data Components/BehaviorManagerSettings", order = 1)]
public class BehaviorSettings : ScriptableObject
{
   [Range(0,500)]
    public float startDistance;
    [Range(0, 500)]
    public float stoppingDistance;

}
