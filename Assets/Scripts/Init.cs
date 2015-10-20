using UnityEngine;
using System.Collections;
using Soomla;
using Soomla.Store;



public class Init : MonoBehaviour {

    public GameObject[] intro;

	// Use this for initialization
	void Start () {
        //PlayerPrefs.DeleteAll();
		StartCoroutine(InitGame ());
        
	}

	IEnumerator InitGame (){
        SoomlaStore.Initialize(new CatAndMouseStore());

        for (int i = 0; i < intro.Length; i++)
        {
            intro[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
		yield return new WaitForSeconds (1);
		Application.LoadLevel (1);
	}
}
