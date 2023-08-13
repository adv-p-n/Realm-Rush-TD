using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }
    [SerializeField] TextMeshProUGUI balanceText;

     void Awake()
    {
        currentBalance = startingBalance;
    }
     void Update()
    {
        UpdateBalanceText();
    }

     void UpdateBalanceText()
    {
        balanceText.text = $" Gold: {currentBalance}";
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

     void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
