using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    [SerializeField] float upState = 2f;
    [SerializeField] float downState = 2f;
    Animator myAnimator = null;

    float timer = Mathf.Epsilon;
    bool isUp = false;
    bool isTransitioning = false;

    private void Awake() 
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Start() 
    {
        isUp = false;
        isTransitioning = false;
    }

    private void Update() 
    {
        RotateStages();

        UpdateTimer();
    }

    private void RotateStages()
    {
        if (!isTransitioning)
        {
            if (isUp && timer >= upState)
            {
                GoDown();
            }
            else if (!isUp && timer >= downState)
            {
                GoUp();
            }
        }
    }

    private void GoDown()
    {
        timer = 0f;
        myAnimator.SetTrigger("GoingDown");
        isUp = false;
    }

    private void GoUp()
    {
        timer = 0f;
        myAnimator.SetTrigger("GoingUp");
        isUp = true;
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
    }

    // Unity Animations events
    public void IsTransitioning()
    {
        isTransitioning = true;
    }

    public void IsNOTTransitioning()
    {
        isTransitioning = false;
        timer = 0f;
    }
}
