using UnityEngine;
using System.Collections;

[System.Serializable]
public class PoolingObjectAttributes
{
		public GameObject PoolingGameObject ;
		public PoolObjectType PoolObjectType;
		public int InitialPoolSize ;		
		public Transform ParentTransform ;
}
