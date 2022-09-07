using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class items
{
    public string name;
    public float[] amountsDirect;
    public itemsInTime[] amountsTime;
    public float price = 0;
    public string description;
    public UnityEvent events;
}

[System.Serializable]
public class itemsInTime
{
    public bool infinite = false;
    public int timeInSecond = 0;
    public float amount = 0;
}