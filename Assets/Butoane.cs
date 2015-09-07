using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Butoane : MonoBehaviour {

	public bool isPaused; // asta tine o valoare
	public GameObject meniu;
	public GameObject b_pauza;
	public GameObject b_resume;
	public GameObject b_play;
	public GameObject b_restart;

	void Start ()
	{
		Time.timeScale = 0f;
		isPaused = true;
	}
	
	public void ShowMenu(string ce) // ShowMenu("mihaela");
	{
		switch (ce) 
		{
			case "pauza":
				Time.timeScale = 0f;  //asta se executa cand e chemat Pauza()
				b_pauza.SetActive (false);
				meniu.SetActive (true);
				b_restart.SetActive(true);
				b_resume.SetActive(true);
				b_play.SetActive(false);
				isPaused = true; //asta se executa cand e chemat Pauza()
				break;

			case "resume":
				Time.timeScale = 1f; //asta se executa cand e chemat Resume()
				meniu.SetActive (false);
				b_pauza.SetActive (true);
				isPaused = false;  //asta se executa cand e chemat Resume()
				break;

			case "restart":
				Time.timeScale = 1f;
				Application.LoadLevel(1);
				break;

			case "play":
				meniu.SetActive(false);
				Time.timeScale = 1f;
				isPaused = false;
				StartCoroutine(Asteapta());
				
				break;


			default:
				break;
		}

	}

	IEnumerator Asteapta()
	{
		yield return new WaitForSeconds (3);
		print ("am asteptat 3 secunde");
	}


}

