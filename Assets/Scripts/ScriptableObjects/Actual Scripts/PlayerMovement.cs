using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data Components/PlayerMovementComponent", order = 1)]
public class PlayerMovement : ScriptableObject
{
    [Range(0,15)]
    public float Speed = 5;
    [Range(0, 1500)]
    public float AngularSpeed;
    [Range(0, 5)]
    public float JumpHeight = 4;
    [Range(0, 10)]
    public float Acceleration = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
}
