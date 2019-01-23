using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public float FuelValue = 100f;
    public float FuelLossPerSecond = 1.5f;
    public float FuelLossIncrease = 0.5f;
    void Update()
    {
        FuelValue -= FuelLossPerSecond * Time.deltaTime;
    }
    public void TakeDamage()
    {
        FuelLossPerSecond += FuelLossIncrease;
    }
}
