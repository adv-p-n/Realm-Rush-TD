using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    Bank bank;
  

    public bool PlaceTower(Tower tower,Transform transform)
    {
        bank = FindObjectOfType<Bank>();
        if (bank== null) { Debug.Log("null"); return false; }
        if(cost<=bank.CurrentBalance)
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
        return false;
    }
}
