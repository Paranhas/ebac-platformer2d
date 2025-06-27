using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
   public static ItemManager Instance;
    public int coin;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coin = 0;
    }
    public void AddCoins(int amount = 1) 
    {
        coin += amount;
    }
}
