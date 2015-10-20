using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    CollectManager GM;

    // Use this for initialization
    void Start()
    {
        GM = FindObjectOfType<CollectManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().CompareTag("Player") && gameObject.CompareTag("coin"))
        {
            GM.StoreTempCoins();
            Destroy(gameObject);
        }
        else if (other.GetComponent<Collider2D>().CompareTag("Player") && gameObject.CompareTag("gem"))
        {
            GM.StoreTempGems();
            Destroy(gameObject);
        }
    }


}
