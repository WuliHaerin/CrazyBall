using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


namespace Crazyball
{
	public class MenuManager : MonoBehaviour
	{
		/// <summary>
		/// Main Menu Controller.
		/// This class handles user clicks on menu button, and also fetch and shows user saved scores on screen.
		/// </summary>

		private int bestScore;              //best saved score
		private int lastScore;              //score of the last play

		//reference to gameObjects
		public Text bestScoreText;
		public Text lastScoreText;

		public AudioClip menuTap;           //sfx for touch on menu buttons

		private bool canTap;                        //are we allowed to click on buttons? (prevents double touch)


		void Awake()
		{
			Time.timeScale = 1.0f;
			AudioListener.volume = 1.0f;

			canTap = true; //player can tap on buttons

			bestScore = PlayerPrefs.GetInt("bestScore");
			bestScoreText.text = bestScore.ToString();

			lastScore = PlayerPrefs.GetInt("lastScore");
			lastScoreText.text = lastScore.ToString();
		}


		void Start()
		{
			//prevent screenDim in handheld devices
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}


		///***********************************************************************
		/// play audio clip
		///***********************************************************************
		void playSfx(AudioClip _sfx)
		{
			GetComponent<AudioSource>().clip = _sfx;
			if (!GetComponent<AudioSource>().isPlaying)
				GetComponent<AudioSource>().Play();
		}


		public void ClickOnExitButton()
        {
			if (!canTap)
                return;
			canTap = false;

			playSfx(menuTap);
			Invoke("ExitDelayed", 0.5f);
		}

		public void ExitDelayed()
        {
			Application.Quit();
		}


		public void ClickOnMoreGamesButton()
		{
			//Add your website link here
			Application.OpenURL("https://www.finalbossgame.com/");
		}


		public void ClickOnEscapeButton()
		{
			if (!canTap)
				return;
			canTap = false;

			playSfx(menuTap);
			PlayerPrefs.SetInt("GameMode", 0);

			Invoke("StartGameDelayed", 0.5f);
		}


		public void ClickOnSurvivalButton()
		{
			if (!canTap)
				return;
			canTap = false;

			playSfx(menuTap);
			PlayerPrefs.SetInt("GameMode", 1);

			Invoke("StartGameDelayed", 0.5f);
		}

		public void StartGameDelayed()
		{
			SceneManager.LoadScene("Game");
		}
	}
}