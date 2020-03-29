using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayersLife : MonoBehaviour
{
    [SerializeField] Globalvariables globalVariables = null;
    [System.Serializable]
    private class Globalvariables
    {
        public IntVariable playerLifes = null;
        public IntVariable playerHP = null;
    }

    [Header("Only Testing")]
    [SerializeField] bool Testing = true;
    [SerializeField] int currentLifes = 3;
    [SerializeField] int currentHPInLife = 100;

    [SerializeField] UnityEvent onGetDamage = null;
    [SerializeField] UnityEvent onLooseLife = null;
    [SerializeField] UnityEvent onDie = null;

    int startingLifes, startingHPInLife;
    bool isInvincible;

    private void Awake() 
    {
        SetStartingValues();
        UpdateGlobalValues();
    }

    private void Update() 
    {
        if (Testing)
        {
            UpdateGlobalValues();
        }
    }

    public void GetDamage(int dmgToDeal)
    {
        TakeHP(dmgToDeal);

        if (currentHPInLife <= 0)
        {
            TakeLife();
            ResetHP();

            onLooseLife.Invoke();
        }

        onGetDamage.Invoke();
    }

    private void TakeHP(int dmgToDeal)
    {
        currentHPInLife -= dmgToDeal;
        UpdateGlobalValues();
    }

    private void TakeLife()
    {
        currentLifes--;
        UpdateGlobalValues();
        if (currentLifes <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        onDie.Invoke();
    }

    private void ResetHP()
    {
        currentHPInLife = startingHPInLife;
        UpdateGlobalValues();
    }

    private void UpdateGlobalValues()
    {
        UpdateGlobalLifes();
        UpdateGlobalHP();
    }

    private void UpdateGlobalLifes()
    {
        globalVariables.playerLifes.SetValue(currentLifes);
    }

    private void UpdateGlobalHP()
    {
        globalVariables.playerHP.SetValue(currentHPInLife);
    }

    private void SetStartingValues()
    {
        startingLifes = currentLifes;
        startingHPInLife = currentHPInLife;

    }
}
