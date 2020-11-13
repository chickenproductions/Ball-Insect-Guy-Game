using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject Player;
    public int keys;
    
    public static GameManger gamemanager;
    // Start is called before the first frame update   
    void Awake()
    {
        gamemanager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
