using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public GameObject characterObj;

	Vector3 destination;

	

	void Start ()
	{

	}
	
    // Update is called once per frame
    void LateUpdate()
    {
        //if (characterObj.transform.position.y < 5)  
        //{
        //    //destination = transform.position + delta1;
        //    destination = new Vector3(characterObj.transform.position.x, characterObj.transform.position.y - 2f, -99);
        //    transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        //}
        //else
        {
            destination = new Vector3(characterObj.transform.position.x + 3f, characterObj.transform.position.y, -99);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}
