/*
 * 
 * Use the object pools to help reduce object instantiation time and performance 
 * with objects that are frequently created and used.
 * 
 * 
 */
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

/// <summary>
/// The object pool is a list of already instantiated game objects of the same type.
/// </summary>
public class ObjectPool
{
		//the list of objects.
		private List<IPoolGameObject> pooledObjects;
		private PoolingObjectAttributes poolingObjectAttributes;

		/// <summary>
		/// Constructor for creating a new Object Pool.
		/// </summary>
		/// <param name="obj">Game Object for this pool</param>
		/// <param name="initialPoolSize">Initial and default size of the pool.</param>
		/// <param name="maxPoolSize">Maximum number of objects this pool can contain.</param>
		/// <param name="shouldShrink">Should this pool shrink back to the initial size.</param>
		public ObjectPool (PoolingObjectAttributes poolingObjectAttributes)
		{
				this.poolingObjectAttributes = poolingObjectAttributes;
				//instantiate a new list of game objects to store our pooled objects in.
				pooledObjects = new List<IPoolGameObject> ();
		
				//create and add an object based on initial size.
				for (int i = 0; i < poolingObjectAttributes.InitialPoolSize; i++) {
						GeneratePoolObject (false);
				}						
		}
		
		/// <summary>
		/// Gets the type of the pool object to be generated.
		/// </summary>
		/// <returns>The pool object type.</returns>
		/// <param name="poolObjectType">Pool object type.</param>
		/// <param name="newPooledObject">New pooled object.</param>
		IPoolGameObject GetPoolObjectType (PoolObjectType poolObjectType, GameObject newPooledObject)
		{
				switch (poolObjectType) {
				case PoolObjectType.EnemyBullet:
				case PoolObjectType.PlayerBullet:
						BulletPoolGameObject bullet = new BulletPoolGameObject ();
						bullet.BulletMovementScript = newPooledObject.GetComponent<BulletMovement> ();
						bullet.BulletAttributeScript = newPooledObject.GetComponent<BulletAttribute> ();
						return bullet;
				default:
						return new PoolGameObject ();
				}
		}
		
		/// <summary>
		/// Generate each bool object and add it to list
		/// </summary>
		/// <returns>The pool object.</returns>
		/// <param name="isActive">If set to <c>true</c> is active.</param>
		IPoolGameObject GeneratePoolObject (bool isActive)
		{
				//instantiate and create a game object with useless attributes.
				//these should be reset anyways.
				GameObject nObj = GameObject.Instantiate (poolingObjectAttributes.PoolingGameObject, Vector3.zero, Quaternion.identity) as GameObject;
		
				IPoolGameObject poolGO = GetPoolObjectType (poolingObjectAttributes.PoolObjectType, nObj);
		
		
				poolGO.PoolingGameObject = nObj;
		
				//set parent transform
				nObj.transform.parent = poolingObjectAttributes.ParentTransform;
		
				//make sure the object isn't active.
				nObj.SetActive (isActive);
		
				//add the object too our list.
				pooledObjects.Add (poolGO);

				return poolGO;
		}

		/// <summary>
		/// Returns an active object from the object pool without resetting any of its values.
		/// You will need to set its values and set it inactive again when you are done with it.
		/// </summary>
		/// <returns>Game Object of requested type if it is available, otherwise null.</returns>
		public IPoolGameObject GetObject ()
		{
				//iterate through all pooled objects.
				for (int i = 0; i < pooledObjects.Count; i++) {
						//look for the first one that is inactive.
						if (!pooledObjects [i].PoolingGameObject.activeInHierarchy) {
								//set the object to active.
								pooledObjects [i].PoolingGameObject.SetActive (true);
								//return the object we found.
								return pooledObjects [i];
						}
				}
				
				//If all objects are busy then create a new object
				return GeneratePoolObject (true);								
		}
	
}
