using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShooting : MonoBehaviour
{
	public bool playerControllable = false;
	public Faction.Side side;

	[Header("Linkings")]
	public BulletPattern bp;
	public GameObject bullet;
	public Transform spawnPoint;

	// Start is called before the first frame update
	void Start()
    {
		ComplexPattern _ = new ComplexPattern();
		_.actions = new Queue<BulletActionNode>();
		
		_.actions.Enqueue( new Fire( -10f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		_.actions.Enqueue( new Fire( -5f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		_.actions.Enqueue( new Fire( 0f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		_.actions.Enqueue( new Fire( 5f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		_.actions.Enqueue( new Fire( 10f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		_.actions.Enqueue( new Fire( 5f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		_.actions.Enqueue( new Fire( 0f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		_.actions.Enqueue( new Fire( -5f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		_.actions.Enqueue( new Fire( -10f ) );
		_.actions.Enqueue( new Delay( 0.2f ) );
		

		/*
		_.actions.Enqueue( new Fire( -10f ) );
		_.actions.Enqueue( new Fire( 0f ) );
		_.actions.Enqueue( new Fire( 10f ) );
		_.actions.Enqueue( new Delay( 0.5f ) );
		_.actions.Enqueue( new Fire( -7f ) );
		_.actions.Enqueue( new Fire( 7f ) );
		_.actions.Enqueue( new Delay( 0.5f ) );
		*/
		_.projectileSpeed = 0.05f;
		bp = _;
		bp.spawnPoint = spawnPoint;
		bp.bullet = bullet;
		bp.side = side;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetButton("Fire1") && playerControllable)
        {
			return;
		}
		bp.Update();
    }

	
}
