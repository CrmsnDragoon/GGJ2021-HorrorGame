using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global 
{
    private static int _health = 2;

    public static int Health
    {
        get => _health;
        set
        {
            _health = value;
            mainUI.Instance.UpdateTotals();
        }
    }
    
}
