using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlayUI : Singleton<GamePlayUI>
{
		public GameObject main;
		public GameObject StartButton;
		public GameObject GoBackButton;
		public Text DescriptionText;
		public Text EnemyCount;
		// Use this for initialization
		void Start ()
		{
				DescriptionText.text = GameManager.Instance.LevelDescription;
				main.SetActive (true);
				
		}

		public void SetWinningMesssage ()
		{
				DescriptionText.text = "You Won.Go Back And Play Next Level.";				
				EnableMain ();
		}

		public void SetYouLooseMesssage ()
		{
				
				DescriptionText.text = "You Loose. Go Back And Play Again.";
				EnableMain ();
		}

		void Update ()
		{
				EnemyCount.text = (GameManager.Instance.NumberOfEnemies - GamePlay.Instance.TotalEnemiesKilled).ToString();
		}

		public void EnableMain ()
		{
				main.SetActive (true);
		}

		public void StartLevel ()
		{
				GamePlay.Instance.isStart = false;
				StartButton.SetActive (false);
				main.SetActive (false);
		}

		public void GoBack ()
		{
				Application.LoadLevel ("Start");
		}

		public void TogglePause ()
		{				
				GamePlay.Instance.isPause = !GamePlay.Instance.isPause;
				main.SetActive (GamePlay.Instance.isPause);
		}
}
