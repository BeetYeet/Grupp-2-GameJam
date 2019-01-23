using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShooting : MonoBehaviour
{

    [Header("Atrubutes")]
    public float projectileSpeed;
    public float firerate;
    private float fireCooldown = 0.1f;

    [Header("Linkings")]
    public GameObject projectile;
    public GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            Shooter();
        }
    }

    void Shooter()
    {

        GameObject newProjectile;

        newProjectile = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);

        fireCooldown = firerate;

    }
}
