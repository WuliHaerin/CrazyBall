using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Crazyball
{
	public class GameoverManager : MonoBehaviour
	{
		/// <summary>
		/// Gameover manager class.
		/// </summary>

		public static GameoverManager instance;

		public Text scoreText;                    //gameobject which shows the score on screen
		public Text bestScoreText;                //gameobject which shows the best saved score on screen

        private void Awake()
        {
			instance = this;
        }

        public void DisplayEndScore()
		{
			//Set the new score on the screen
			scoreText.text = PlayerManager.playerScore.ToString();
            saveScore();
            bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
		}

        private void Start()
        {
			
		}


		///***********************************************************************
		/// Save player score
		///***********************************************************************
		void saveScore()
		{
			//immediately save the last score
			PlayerPrefs.SetInt("lastScore", PlayerManager.playerScore);
			//check if this new score is higher than saved bestScore.
			//if so, save this new score into playerPrefs. otherwise keep the last bestScore intact.
			int lastBestScore;
			lastBestScore = PlayerPrefs.GetInt("bestScore");
			if (PlayerManager.playerScore > lastBestScore)
				PlayerPrefs.SetInt("bestScore", PlayerManager.playerScore);
		}

	}
}