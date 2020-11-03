using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data Components/PlayerMovementComponent", order = 1)]
public class PlayerMovement : ScriptableObject
{
    public float Speed = 5;
    public float AngularSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
}
