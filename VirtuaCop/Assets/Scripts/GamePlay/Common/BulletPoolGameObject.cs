using UnityEngine;
using System.Collections;

[System.Serializable]
public class BulletPoolGameObject :  PoolGameObject, IBulletPoolObject
{		
		public BulletMovement BulletMovementScript { get; set; }
	
		public BulletAttribute BulletAttributeScript { get; set; }		
}
