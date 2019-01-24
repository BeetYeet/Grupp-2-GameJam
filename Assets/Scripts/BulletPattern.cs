using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletPattern
{
	public float projectileSpeed = 1f;
	public Faction.Side side;
	internal float fireCooldown = 0f;
	public GameObject bullet;
	public Transform spawnPoint;

	internal void Shoot( float direction )
	{
		Quaternion dir = spawnPoint.rotation * create_from_axis_angle( 0f, 0f, 1f, direction );
		GameObject b = Object.Instantiate( bullet, spawnPoint.position, dir );
		b.GetComponent<BulletMovement>().Initialize( projectileSpeed, side );
	}
	public abstract void Update();

	Quaternion create_from_axis_angle( float xx, float yy, float zz, float a )
	{
		a *= Mathf.PI / 180;
		// Here we calculate the sin( theta / 2) once for optimization
		float factor = Mathf.Sin( a / 2.0f );

		// Calculate the x, y and z of the quaternion
		float x = xx * factor;
		float y = yy * factor;
		float z = zz * factor;

		// Calcualte the w value by cos( theta / 2 )
		float w = Mathf.Cos( a / 2.0f );

		return new Quaternion( x, y, z, w );
	}
}

public class BasicPattern: BulletPattern
{
	public float firerate;

	public BasicPattern( float firerate )
	{
		this.firerate = firerate;
	}

	public override void Update()
	{
		fireCooldown -= Time.deltaTime;
		if ( fireCooldown <= 0f )
		{
			Shoot( 0f );
			fireCooldown += firerate;
		}
	}
}

public class ComplexPattern: BulletPattern
{
	public Queue<BulletActionNode> actions;

	public override void Update()
	{
		fireCooldown -= Time.deltaTime;
		if ( fireCooldown <= 0f )
		{
			Process();
		}
	}

	void Process()
	{
		BulletActionNode action = actions.Dequeue();
		action.Trigger( this );
		actions.Enqueue( action );
		if ( actions.Peek().GetType() != typeof( Delay ) )
		{
			Process();
		}
	}
}


public abstract class BulletActionNode
{
	public abstract void Trigger( BulletPattern parent );
}
public class Delay: BulletActionNode
{
	public float delayTime;

	public Delay( float delayTime )
	{
		this.delayTime = delayTime;
	}

	public override void Trigger( BulletPattern parent )
	{
		parent.fireCooldown += delayTime;
	}
}
public class Fire: BulletActionNode
{
	public float direction;

	public Fire( float direction )
	{
		this.direction = direction;
	}

	public override void Trigger( BulletPattern parent )
	{
		parent.Shoot( direction );
	}
}
public class FireRandom: BulletActionNode
{
	public float directionMin;
	public float directionMax;

	public FireRandom( float directionMin, float directionMax )
	{
		this.directionMin = directionMin;
		this.directionMax = directionMax;
	}

	public override void Trigger( BulletPattern parent )
	{
		parent.Shoot( Random.Range( directionMin, directionMax ) );
	}
}

