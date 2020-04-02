using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BvsM.Score    
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] IntVariable scoreValue = null;
        [SerializeField] int limitForLevel = 3000;

        void Start()
        {
            scoreValue.SetValue(0);
        }

        public void AddScore(int scoreToAdd)
        {
            int currentScore = scoreValue.GetValue();
            int updatedScore = currentScore + scoreToAdd;
            scoreValue.SetValue(updatedScore);

            if (updatedScore > limitForLevel)
            {
                GameFlowManager.NextLevel();
            }

        }
    }
}
