using UnityEngine;
using System.Collections;

public interface IBulletPoolObject
{
		BulletMovement BulletMovementScript { get; set; }

		BulletAttribute BulletAttributeScript { get; set; }
}
