using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{

    public GameObject StartLaser;
    public GameObject TheLaser;
    public GameObject EndLaser;


    public float LifeTime;

    // Start is called before the first frame update
    void Start()
    {
        //TheLaser.GetComponent<LASER>().LaserDurasion = LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FIRETHELASER();
        }
    }

    void FIRETHELASER()
    {

        //GameObject newLASER = Instantiate(TheLaser, transform.position, transform.rotation);

        StartCoroutine(LaserTiming());

    }

    IEnumerator LaserTiming()
    {

        GameObject newLASER = Instantiate(StartLaser, transform.position, transform.rotation);

        Destroy(newLASER, 0.8f);
        yield return new WaitForSeconds(0.8f);

        GameObject newMidLASER = Instantiate(TheLaser, transform.position, transform.rotation);

        Destroy(newMidLASER, 1f);
        yield return new WaitForSeconds(1);

        GameObject newEndLASER = Instantiate(EndLaser, transform.position, transform.rotation);

        Destroy(newEndLASER, 0.8f);
        yield return new WaitForSeconds(0.8f);

    }
}
