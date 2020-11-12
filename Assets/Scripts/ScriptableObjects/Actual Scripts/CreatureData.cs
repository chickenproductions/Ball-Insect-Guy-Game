using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Health", menuName = "Data Components/Health", order = 1)]
public class CreatureData : ScriptableObject
{
    [Range(1,100)]
    public int Health;
}
