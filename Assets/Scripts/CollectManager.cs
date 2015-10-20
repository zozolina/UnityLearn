using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla;
using Soomla.Store;

public class CollectManager : MonoBehaviour {

    int tCoins;
    int tGems;
    public Text coinText;
    public Text gemText;

    void Start()
    {
        //reset temporary values to zero
        tCoins = 0;
        tGems = 0;
    }

    //store temporary coins that were collected during a run
    public void StoreTempCoins()
    {
        tCoins++;
        coinText.text = tCoins.ToString();
    }

    //store temporary gems that were collected during a run
    public void StoreTempGems()
    {
        tGems++;
        gemText.text = tGems.ToString();
    }

    //Update coins when player dies / end run
    public void UpdateCollectibles()
    {
        StoreInventory.GiveItem(CatAndMouseStore.COIN_CURRENCY_ID, tCoins);
        StoreInventory.GiveItem(CatAndMouseStore.GEM_CURRENCY_ID, tGems);
    }
}
