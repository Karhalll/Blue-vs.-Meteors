using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BvsM.UI
{
    public class LifesUI : MonoBehaviour
    {
        [SerializeField] IntVariable lifes = null;
        [SerializeField] IntVariable HP = null;
        [SerializeField] LifeUI halfHP = null;
        [SerializeField] LifeUI livePrefab = null;

        private void Start() 
        {
            UpdateCanvas();
        }

        public void UpdateCanvas()
        {
            ClearLifes();
            int currentLifes = GetLifes();
            for (int i = 1; i <= currentLifes; i++ )
            {
                if (i == currentLifes && HP.GetValue() < 100)
                {
                    Instantiate(
                        halfHP,
                        transform.position,
                        Quaternion.identity,
                        transform
                    );
                }
                else
                {
                    Instantiate(
                        livePrefab,
                        transform.position,
                        Quaternion.identity,
                        transform
                    );
                }

            }
        }

        private void ClearLifes()
        {
            LifeUI[] lives = gameObject.GetComponentsInChildren<LifeUI>();
            foreach (LifeUI live in lives)
            {
                Destroy(live.gameObject);
            }
        }

        private int GetLifes()
        {
            return lifes.GetValue();
        }
    }
}
