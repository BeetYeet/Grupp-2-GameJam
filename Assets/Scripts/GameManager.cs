using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager current;

    public float DistanceTraveled;
    public bool pauseTravel;

    // Start is called before the first frame update
    void Awake()
    {
        if (current != null)
        {
            throw new System.Exception("There can't Be 2 Game Controllers, duh");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseTravel)
        {
            DistanceTraveled += Time.deltaTime; 
        }
    }
}
