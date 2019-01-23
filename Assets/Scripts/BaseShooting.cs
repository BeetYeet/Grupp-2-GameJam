using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShooting : MonoBehaviour
{

    [Header("Atrubutes")]
    public float projectileSpeed;
    public float firerate;
    private float fireCooldown = 0.1f;
	public Faction.Side side;

	[Header("Linkings")]
    public GameObject projectile;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(Input.GetButton("Fire1") && fireCooldown <= 0)
        {
            Shooter();
        }
    }

    void Shooter()
    {

        GameObject newProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
		newProjectile.GetComponent<BulletMovement>().Initialize(projectileSpeed, side);
        fireCooldown = firerate;

    }
}
