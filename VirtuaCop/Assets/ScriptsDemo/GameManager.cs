using UnityEngine;
using System.Collections;

public class GameManager : SingletonPersistant<GameManager>
{
		public string LevelDescription {
				get;
				set;
		}

		public int NumberOfEnemies {
				get;
				set;
		}

		public Compass[] SupportedDirection {
				get;
				set;
		}
		
		public int MaximumEnimiesAtATime {
				get;
				set;
		}

		public void SetLaodingLevelDetails (string levelName)
		{
				switch (levelName) {
				case "Level 1":
						NumberOfEnemies = 20;
						SupportedDirection = new Compass[]{Compass.North};
						MaximumEnimiesAtATime = 5;
						LevelDescription = "Tap on enemy to shoot. \n Kill 20 enemies before you die.";
						break;
				case "Level 2":
						NumberOfEnemies = 15;
						SupportedDirection = new Compass[]{ Compass.North , Compass.South};
						MaximumEnimiesAtATime = 3;
						LevelDescription = "Swipe Left & Right. \n  Kill 15 enemies before you die.";
						break;
				case "Level 3":
						NumberOfEnemies = 10;
						SupportedDirection = new Compass[]{Compass.North , Compass.East , Compass.West};
						MaximumEnimiesAtATime = 3;
						LevelDescription = "Swipe Left & Right. \n Kill 10 enemies before you die.";
						break;
				case "Level 4":
						NumberOfEnemies = 6;
						SupportedDirection = new Compass[] {
								Compass.North ,
								Compass.East ,
								Compass.West ,
								Compass.South
						};
						MaximumEnimiesAtATime = 3;
						LevelDescription = "Swipe Left & Right. \n Kill 6 enemies before you die.";
						break;
				}
		}
}
