using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] IntVariable scorevariable = null;

    Text myText = null;

    private void Awake() 
    {
        myText = GetComponent<Text>();
    }

    private void Update() 
    {
        myText.text = scorevariable.GetValue().ToString("### ##0");
    }
}
