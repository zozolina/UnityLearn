using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla;
using Soomla.Store;

public class MenuController : MonoBehaviour
{

    public bool isPaused; // asta tine o valoare
    public GameObject topMenu;
    public GameObject bottomMenu;
    public GameObject shopMenu;
    public GameObject b_play;

    [Header("Modal Window Properties")]
    public GameObject mw;
    public Text mw_Title;
    public Text mw_Body;

    [Header("Top Menu")]
    public GameObject coinCurrencyBalanceTxt;
    public GameObject gemCurrencyBalanceTxt;
    public GameObject pauseMenu;
    public GameObject upgradeMenu;

    string wasRestart = "wasRestart";



    void Start()
    {
        UpdateUI();

        if (PlayerPrefs.GetInt(wasRestart) == 9)
        {
            isPaused = true;
            StartCoroutine(Asteapta());
            topMenu.SetActive(true);
            bottomMenu.SetActive(true);
            b_play.SetActive(false);
            pauseMenu.SetActive(false);
            shopMenu.SetActive(false);
            PlayerPrefs.SetInt(wasRestart, 0);
        }
        else
        {
            isPaused = true;
            topMenu.SetActive(false);
            bottomMenu.SetActive(false);
            pauseMenu.SetActive(false);
            shopMenu.SetActive(false);

        }
    }

    void OnApplicationPause()
    {
        ShowMenu("pauza");

    }

    void OnApplicationFocus()
    {
        ShowMenu("pauza");
    }

    public void ShowMenu(string ce)
    {
        switch (ce)
        {
            case "pauza":
                shopMenu.SetActive(false);
                upgradeMenu.SetActive(false);
                b_play.SetActive(false);
                pauseMenu.SetActive(true);
                isPaused = true;
                break;

            case "resume":
                pauseMenu.SetActive(false);
                topMenu.SetActive(true);
                bottomMenu.SetActive(true);
                shopMenu.SetActive(false);
                upgradeMenu.SetActive(false);
                isPaused = false;
                SoomlaStore.StopIabServiceInBg();
                break;

            case "restart":
                PlayerPrefs.SetInt(wasRestart, 9);
                Application.LoadLevel(1);
                break;

            case "play":
                b_play.SetActive(false);
                isPaused = true;
                StartCoroutine(Asteapta());
                topMenu.SetActive(true);
                bottomMenu.SetActive(true);
                break;

            case "shop":
                isPaused = true;
                pauseMenu.SetActive(false);
                bottomMenu.SetActive(false);
                SoomlaStore.StartIabServiceInBg();
                shopMenu.SetActive(true);
                break;

            case "upgrade":
                isPaused = true;
                pauseMenu.SetActive(false);
                SoomlaStore.StartIabServiceInBg();
                bottomMenu.SetActive(false);
                upgradeMenu.SetActive(true);
                break;

            case "quit":
                Application.Quit();
                break;


            default:
                break;
        }

    }

    IEnumerator Asteapta()
    {
        yield return new WaitForSeconds(3);
        isPaused = false;
    }

    public void ShowModalWindow(string title, string body)
    {
        mw.SetActive(true);
        mw_Title.text = title;
        mw_Body.text = body;
    }

    public void CloseModalWindow()
    {
        mw.SetActive(false);
    }

    public void UpdateUI()
    {
        coinCurrencyBalanceTxt.GetComponent<Text>().text = (StoreInventory.GetItemBalance(StoreInfo.Currencies[0].ItemId) + "C");
        gemCurrencyBalanceTxt.GetComponent<Text>().text = (StoreInventory.GetItemBalance(StoreInfo.Currencies[1].ItemId) + "G");
    }

    //Try to buy a coin pack
    public void BuyItem(string ItemID)
    {
        if (StoreInventory.CanAfford(ItemID))
        {
            StoreInventory.BuyItem(ItemID);
        }
        else
        {
            ShowModalWindow("Purchase Failed", "You don't have enough Coins to buy this item. Continue playing to earn more Coins or visit the Shop!");
        }
    }

    public void BuyUpgrade(string ItemID)
    {
        if (StoreInventory.CanAfford(ItemID)) 
        {
            if (StoreInventory.GetItemBalance(ItemID) != 0 )
            {
                ShowModalWindow("Purchase Failed", "You already own this item!");
            }
            else
            {
                StoreInventory.BuyItem(ItemID);
            }
        }
        else
        {
            ShowModalWindow("Purchase Failed", "You don't have enough Coins to buy this item. Continue playing to earn more Coins or visit the Shop!");
        }
    }

}