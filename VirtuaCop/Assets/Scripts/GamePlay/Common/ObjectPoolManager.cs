/*
 * @Author: David Crook
 * 
 * Use this singleton Object Pooling Manager Class to manage a series of object pools.
 * Typical uses are for particle effects, bullets, enemies etc. 
 * 
 * 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObjectPoolManager:Singleton<ObjectPoolManager>
{
	
		//the variable is declared to be volatile to ensure that 
		//assignment to the instance variable completes before the 
//		//instance variable can be accessed.
//		private static volatile ObjectPoolManager instance;
	
		//look up list of various object pools.
		private Dictionary<PoolObjectType, ObjectPool> objectPools;
	
		//object for locking
		//private static object syncRoot = new System.Object ();
	
		/// <summary>
		/// Constructor for the class.
		/// </summary>
		private ObjectPoolManager ()
		{
				//Ensure object pools exists.
				this.objectPools = new Dictionary<PoolObjectType, ObjectPool> ();
		}
	
		
		/// <summary>
		/// Create a new object pool of the objects you wish to pool
		/// </summary>
		/// <param name="objToPool">The object you wish to pool.  The name property of the object MUST be unique.</param>
		/// <param name="initialPoolSize">Number of objects you wish to instantiate initially for the pool.</param>
		/// <param name="maxPoolSize">Maximum number of objects allowed to exist in this pool.</param>
		/// <param name="shouldShrink">Should this pool shrink back down to the initial size when it receives a shrink event.</param>
		/// <returns></returns>
		public bool CreatePool (PoolingObjectAttributes poolingObjectAttributes)
		{
				//Check to see if the pool already exists.
				if (objectPools.ContainsKey (poolingObjectAttributes.PoolObjectType)) {
						//let the caller know it already exists, just use the pool out there.
						return false;
				} else {
						//create a new pool using the properties
						ObjectPool nPool = new ObjectPool (poolingObjectAttributes);
						//Add the pool to the dictionary of pools to manage 
						//using the object name as the key and the pool as the value.
						objectPools.Add (poolingObjectAttributes.PoolObjectType, nPool);
						//We created a new pool!
						return true;
				}
		}
	
		/// <summary>
		/// Get an object from the pool.
		/// </summary>
		/// <param name="objName">String name of the object you wish to have access to.</param>
		/// <returns>A GameObject if one is available, else returns null if all are currently active and max size is reached.</returns>
		public IPoolGameObject GetObject (PoolObjectType poolObjectType)
		{
				//Find the right pool and ask it for an object.
				return objectPools [poolObjectType].GetObject ();
		}
}