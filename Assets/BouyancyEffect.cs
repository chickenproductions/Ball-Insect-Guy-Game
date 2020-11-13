using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class BouyancyEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public float Amplitude;
    public float RotationAmplitude;
    public float Speed;
    public float frequency;
    float wave;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wave = Amplitude * Mathf.Sin((Time.time * Speed)  + frequency);
        float Rotwave = RotationAmplitude * Mathf.Sin((Time.time * Speed) + frequency)  ;
        transform.position = new Vector2(transform.position.x,transform.position.y + wave );
        transform.eulerAngles = new Vector3(0, 0, Rotwave);
    }
}
