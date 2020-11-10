using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        if(SceneManager.sceneCount >= 3)
        {
            SceneManager.UnloadSceneAsync("Scene1");
            SceneManager.UnloadSceneAsync("Scene2");
            SceneManager.UnloadSceneAsync("Scene3");
        }        
        LoadScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene()
    {
        SceneManager.LoadSceneAsync("Scene1", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Scene2", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Scene3", LoadSceneMode.Additive);
        
    }
}
