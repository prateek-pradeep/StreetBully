using UnityEngine;
using System.Collections;

public class GamePlay : Singleton<GamePlay>
{
		public int TotalEnemiesKilled {
				get;
				set;
		}

		public bool isStart {
				get;
				set;
		}

		public bool isEnd {
				get;
				set;
		}

		public bool isPause {
				get;
				set;
		}

		int numberOfEnemiesToBeKilled;
		GameObject UIElement;

		void Awake ()
		{
				isStart = true;
				TotalEnemiesKilled = 0;
				numberOfEnemiesToBeKilled = GameManager.Instance.NumberOfEnemies;
		}

		void Update ()
		{
				if (!isEnd && TotalEnemiesKilled == numberOfEnemiesToBeKilled) {
						isEnd = true;
						GamePlayUI.Instance.SetWinningMesssage ();
				}
		}

		public bool IsMaximumEnemies ()
		{
				return numberOfEnemiesToBeKilled == TotalEnemiesKilled;
		}

		public int GetRemainingEnemies ()
		{
				return numberOfEnemiesToBeKilled - TotalEnemiesKilled;
		}
	
}
