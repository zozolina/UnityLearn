using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Butoane : MonoBehaviour {

	public bool isPaused; // asta tine o valoare
	public GameObject meniu;
	public GameObject b_pauza;

	public void Pauza () //asta poate fi chemat
	{
		Time.timeScale = 0f;  //asta se executa cand e chemat Pauza()
		meniu.SetActive (true);
		b_pauza.SetActive (false);
		isPaused = true; //asta se executa cand e chemat Pauza()
	}

	public void Resume () //asta poate fi chemat
	{
		Time.timeScale = 1f; //asta se executa cand e chemat Resume()
		meniu.SetActive (false);
		b_pauza.SetActive (true);
		isPaused = false;  //asta se executa cand e chemat Resume()
	}


}

