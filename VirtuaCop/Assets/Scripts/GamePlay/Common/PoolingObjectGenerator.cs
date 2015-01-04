using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class PoolingObjectGenerator : MonoBehaviour
{

		public List<PoolingObjectAttributes> poolingObjects;

		// Use this for initialization
		void Awake ()
		{
				Transform myT = transform;

				if (poolingObjects != null) {
						foreach (var obj in poolingObjects) {
								//safety check
								if (obj.PoolingGameObject == null) {
										Debug.LogError ("No pooling game object selected for PoolObjectType " + obj.PoolObjectType.ToString ());
										continue;
								}

								//create a new parent object that will hold collection of pooled object
								GameObject parentObject = new GameObject (obj.PoolObjectType.ToString ());
								//set this parent object under current game object
								parentObject.transform.parent = myT;
								//set the pooling object parent to newly created parent object
								obj.ParentTransform = parentObject.transform;
								//create the pooling object
								ObjectPoolManager.Instance.CreatePool (obj);
						}
				}
		}			
}
