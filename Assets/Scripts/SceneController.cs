﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    int currentScene = 0;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
