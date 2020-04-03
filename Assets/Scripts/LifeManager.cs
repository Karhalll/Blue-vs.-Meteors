using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class LifeManager : ScriptableObject
{
    [SerializeField] IntVariable lifesSO;
    [SerializeField] IntVariable HPSO;

    [SerializeField] int maxLifes = 5;

    [SerializeField] UnityEvent onGetHp = null;

    public void AddHealth(int healthToAdd)
    {
        int currentLifes = lifesSO.GetValue();
        if (HPSO.GetValue() >= 100)
        {
            if (currentLifes < maxLifes)
            {
                AddLife(currentLifes);
                SetHP(healthToAdd);
            }
        }
        else
        {
            SetHP(100);
        }

        onGetHp.Invoke();
    }

    private void AddLife(int currentLifes)
    {
        lifesSO.SetValue(currentLifes + 1); 
    }

    private void SetHP(int HP)
    {
        HPSO.SetValue(HP);
    }
}
