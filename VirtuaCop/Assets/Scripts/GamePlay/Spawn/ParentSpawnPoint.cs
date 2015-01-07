using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class ParentSpawnPoint : MonoBehaviour
{		
		SpawnPointTypes spawnPointType = SpawnPointTypes.HiddenSpawn;
		public List<Transform> fixedPoints;
		public List<Transform> bunnyHopPoints;
		public List<Transform> roamingPoints;
		public List<Transform> coverPoints;
		[HideInInspector]
		public Transform
				myTransform;
		public SpawnPointTypes supportedSpawnPoint;

		void Awake ()
		{
				myTransform = transform;
				InitializePoints ();
		}

		void ClearAllPoints ()
		{
				fixedPoints.Clear ();
				bunnyHopPoints.Clear ();
				roamingPoints.Clear ();
				coverPoints.Clear ();
		}

		public void InitializePoints ()
		{
				ClearAllPoints ();
				foreach (Transform child in transform) {
						var childSpawn = child.GetComponent<ChildSpawnPoint> ();
						
						if ((SpawnPointTypes.Fixed & childSpawn.spawnPointType) == SpawnPointTypes.Fixed) {
								fixedPoints.Add (child);
						}
						if ((SpawnPointTypes.BunnyHop & childSpawn.spawnPointType) == SpawnPointTypes.BunnyHop) {
								bunnyHopPoints.Add (child);
						}
						if ((childSpawn.spawnPointType & SpawnPointTypes.Roaming) == SpawnPointTypes.Roaming) {
								roamingPoints.Add (child);				
						}
						if ((childSpawn.spawnPointType & SpawnPointTypes.Cover) == SpawnPointTypes.Cover) {
								coverPoints.Add (child);				
						}
				}

				UpdateSupportedSpawnType ();
				
		}

		void UpdateSupportedSpawnType ()
		{				
				supportedSpawnPoint = SpawnPointTypes.All;
				supportedSpawnPoint &= ~SpawnPointTypes.HiddenSpawn;

				if (fixedPoints == null || fixedPoints.Count < 1) {	
						supportedSpawnPoint &= ~SpawnPointTypes.Fixed;
				}

				if (bunnyHopPoints == null || bunnyHopPoints.Count < 2) {
						supportedSpawnPoint &= ~SpawnPointTypes.BunnyHop;
				}

				if (roamingPoints == null || roamingPoints.Count < 2) {
						supportedSpawnPoint &= ~SpawnPointTypes.Roaming;
				}

				if (coverPoints == null || coverPoints.Count < 1) {
						supportedSpawnPoint &= ~SpawnPointTypes.Cover;
				}

		}

		public void OnDrawGizmos ()
		{
				Gizmos.color = Color.white;
				Gizmos.DrawCube (transform.position, new Vector3 (0.6f, 0.6f, 0.6f));
		}
		
		public IEnumerable<Transform> GetCompatiblePoints (SpawnPointTypes type)
		{
				switch (type) {
				case SpawnPointTypes.BunnyHop:
						return GetBunnyHopPoints (); 
						break;
				case SpawnPointTypes.Cover:
						return GetCoverPoints ();
						break;
				case SpawnPointTypes.Roaming:
						return GetRoamingPoints ();
						break;
				case SpawnPointTypes.Fixed:
						return GetFixedPoints ();
						break;
				}
				return null;
		}

		public IEnumerable<Transform> GetFixedPoints ()
		{
				if (fixedPoints != null) {
						return fixedPoints.Where (fix => fix.gameObject.activeSelf);
						;
				}
				return null;
		}

		public IEnumerable<Transform> GetBunnyHopPoints ()
		{
				if (bunnyHopPoints != null) {
						return bunnyHopPoints.Where (bunny => bunny.gameObject.activeSelf);
				}
				return null;
		}

		public IEnumerable<Transform> GetRoamingPoints ()
		{
				if (roamingPoints != null) {
						return roamingPoints.Where (roaming => roaming.gameObject.activeSelf);
				}
				return null;
		}

		public IEnumerable<Transform> GetCoverPoints ()
		{
				if (coverPoints != null) {
						return coverPoints.Where (roaming => roaming.gameObject.activeSelf);
				}
				return null;
		}

		
}
