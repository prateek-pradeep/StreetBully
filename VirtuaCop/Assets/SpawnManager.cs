using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
		ParentSpawnPoint[] spawnPoints;
		Transform myT;

		void Awake ()
		{
				myT = transform;
				spawnPoints = new ParentSpawnPoint[myT.childCount];
		}
		
		void Start ()
		{
				// Get all child Spawn points
				int count = 0;
				foreach (Transform child in myT) {
						spawnPoints [count++] = child.gameObject.GetComponent<ParentSpawnPoint> ();						
				}
				SpawnEnemy ();
		}
				
		void SpawnEnemy ()
		{
				Transform enemy1 = PoolManager.Pools [Constants.ENEMY_POOL].Spawn (Constants.ENEMY1_POOL_PREFAB);				
				enemy1.gameObject.SetActive (true);
				var movementScript = enemy1.gameObject.GetComponent<EnemyMovement> ();
				ParentSpawnPoint parentSpawnPoint = GetSupportedSpawnPoint (movementScript.enemyType);
				enemy1.position = parentSpawnPoint.myTransform.position;
				IEnumerable<Transform> allTransform = parentSpawnPoint.GetCompatiblePoints (movementScript.enemyType);
				int index = Random.Range (0, allTransform.Count ());
				movementScript.SetFixedPoint (allTransform.ElementAt (index).position);
				
		}

		ParentSpawnPoint GetSupportedSpawnPoint (SpawnPointTypes enemySpawnType)
		{
				//Also check if spawn is free
				IEnumerable<ParentSpawnPoint> supportedSpawnLIst = spawnPoints.Where (spawn => (spawn.supportedSpawnPoint & enemySpawnType) == enemySpawnType);
				int index = Random.Range (0, supportedSpawnLIst.Count ());
				return supportedSpawnLIst.ElementAt (index);
		}

		void GetAvailableSpawnPoint (SpawnPointTypes spawnType)
		{
				//return 
		}
		// Update is called once per frame
		void Update ()
		{
			
		}
}
