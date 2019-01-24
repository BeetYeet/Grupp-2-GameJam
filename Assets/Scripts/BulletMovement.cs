using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement: MonoBehaviour
{
	float movementSpeed = 1f;
	Faction.Side side;

	public void Initialize( float movementSpeed, Faction.Side bulletSide )
	{
		this.movementSpeed = movementSpeed;
		side = bulletSide;
	}

	void Update()
	{
		transform.Translate( transform.up * movementSpeed );
	}

	private void OnCollisionEnter2D( Collision2D collision )
	{
		SendMessageUpwards( "TakeDamage", new DamageInfo(side, ()=> { Destroy( gameObject ); } ) );
	}
}
