using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    CollectManager CM;

	// Use this for initialization
	void Start () {
        CM = FindObjectOfType<CollectManager>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<Collider2D>().CompareTag("Player"))
        {
            //player is dead = do stuff for dead players here
            CM.UpdateCollectibles();
        }
    }
}
