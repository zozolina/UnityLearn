using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(InitGame ());
	}

	IEnumerator InitGame (){
		yield return new WaitForSeconds (3);
		Application.LoadLevel (1);
	}
}
