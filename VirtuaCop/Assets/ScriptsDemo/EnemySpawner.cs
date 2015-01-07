using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{

		public int maximumNumberOfEnemy = 4;
		public List <GameObject> enemyTypeList;
		GameObject spawnRoot;
		Transform enemyList;
		List<Vector3> spawnLocationList;
		List<int> usedSpawnLocation;
		bool isSpawning = false;
		int maxEnemiesAtATime;

		void Awake ()
		{
				spawnRoot = GameObject.FindGameObjectWithTag ("SpawnList");
				enemyList = GameObject.FindGameObjectWithTag ("EnemyList").transform;
				spawnLocationList = new List<Vector3> ();
				usedSpawnLocation = new List<int> ();

				
				SetSpawnLocationList ();
				maxEnemiesAtATime = GameManager.Instance.MaximumEnimiesAtATime;				
		}

		// Use this for initialization
		void Start ()
		{


		}
	
		// Update is called once per frame
		void Update ()
		{
				if (GamePlay.Instance.isStart)
						return;
				if (!isSpawning && enemyList.childCount < Mathf.Min (maxEnemiesAtATime, GamePlay.Instance.GetRemainingEnemies ()) 
						&& !GamePlay.Instance.IsMaximumEnemies ()) {
						isSpawning = true;
						StartCoroutine (Spawn ());
				}
		}

		IEnumerator Spawn ()
		{
				yield return new  WaitForSeconds (1);				
				isSpawning = false;
				
				int enemytype = GetRandomEnemyType ();
				int spawner = GetRandomSpawnPoint ();				

				GameObject childGO = Instantiate (enemyTypeList [enemytype], spawnLocationList [spawner], Quaternion.identity) as GameObject;
				childGO.transform.parent = enemyList;
		}

		void SetSpawnLocationList ()
		{				
				//fetching all the spawn location
				//get all spawn direction from the parent 
				foreach (Transform eachSpawnDirection in spawnRoot.transform) {
						//iterate through the supported direction
						foreach (var direction in GameManager.Instance.SupportedDirection) {
								//check if direction supported equals the child GameObject Transfrom
								if (direction.ToString ().Equals (eachSpawnDirection.name)) {
										//fill the spawn location 
										foreach (Transform spawnLocation in eachSpawnDirection) {
												spawnLocationList.Add (spawnLocation.position);				
										}						

								}

						}
				}
		}

		int GetRandomEnemyType ()
		{
				if (enemyTypeList.Count > 1) {
						return Random.Range (0, enemyTypeList.Count);
				}
				return 0;
		}

		void ResetSpawnLocation ()
		{
				if (usedSpawnLocation.Count == spawnLocationList.Count) {
						usedSpawnLocation.Clear ();
				}
		}

		int GetRandomSpawnPoint ()
		{
				ResetSpawnLocation ();

				int spawnIndex = 0;
				if (spawnLocationList.Count > 1) {
						do {
								spawnIndex = Random.Range (0, spawnLocationList.Count);
						} while(usedSpawnLocation.Contains(spawnIndex));
				}
				usedSpawnLocation.Add (spawnIndex);
				return spawnIndex;
		}
}

