using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LASER : MonoBehaviour
{
    //public float LaserDurasion;
    private Collider2D LasColl;
    private SpriteRenderer spritRend;

    // Start is called before the first frame update
    void Start()
    {
        LasColl = GetComponent<Collider2D>();
        spritRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DamageTics());
        //Destroy(gameObject, LaserDurasion);
    }

    IEnumerator DamageTics()
    {
        while (true)
        {

            LasColl.enabled = false;
            yield return new WaitForSeconds(0.5f);

            LasColl.enabled = true;
            yield return new WaitForSeconds(0.5f);

        }

    }
}
