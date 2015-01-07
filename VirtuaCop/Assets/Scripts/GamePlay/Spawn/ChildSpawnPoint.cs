using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ChildSpawnPoint : MonoBehaviour
{
		public SpawnPointTypes spawnPointType;
		List<Transform> childCoverFixedPoints;
		Transform myT;

		void Awake ()
		{
				myT = transform;
		}

		void InitializeChildPoints ()
		{
				if (childCoverFixedPoints == null)
						childCoverFixedPoints = new List<Transform> ();
				childCoverFixedPoints.Clear ();

				foreach (Transform child in myT) {
						childCoverFixedPoints.Add (child);
				}
		}
		
		public IEnumerable GetChildCoverFixedPoints ()
		{
				if (childCoverFixedPoints != null) {
						return	childCoverFixedPoints.Where (cover => cover.gameObject.activeSelf).Select (coverLocation => coverLocation);
				}
				return null;
		}

		public void OnDrawGizmos ()
		{
				myT = transform;				

				if ((SpawnPointTypes.HiddenSpawn & spawnPointType) == SpawnPointTypes.HiddenSpawn) {
			
						Gizmos.color = Color.white;
						Gizmos.DrawSphere (transform.position, .75f);
				}
				if ((SpawnPointTypes.Fixed & spawnPointType) == SpawnPointTypes.Fixed) {
						
						Gizmos.color = Color.red;
						Gizmos.DrawSphere (transform.position, .6f);
				}
				if ((SpawnPointTypes.BunnyHop & spawnPointType) == SpawnPointTypes.BunnyHop) {
						Gizmos.color = Color.yellow;
						Gizmos.DrawSphere (transform.position, 0.45f);
				}
				if ((spawnPointType & SpawnPointTypes.Roaming) == SpawnPointTypes.Roaming) {
						Gizmos.color = Color.blue;
						Gizmos.DrawSphere (transform.position, 0.3f);						
				}
				
				if ((spawnPointType & SpawnPointTypes.Cover) == SpawnPointTypes.Cover) {
						Gizmos.color = Color.red;
						Gizmos.DrawCube (transform.position, new Vector3 (0.5f, 0.5f, 0.5f));
					
						foreach (Transform child in myT) {
								Gizmos.DrawLine (myT.position, child.position);
						}
				}
		}
		
}
