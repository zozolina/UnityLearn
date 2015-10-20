using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store
{
    public class StoreEventHandler : MonoBehaviour
    {
//#if UNITY_EDITOR
//        public static StoreEventHandler Instance { get; private set; }
//#else
//        public static StoreEventHandler Instance = null;
//#endif
        MenuController mCtrl;

        public StoreEventHandler()
        {
            StoreEvents.OnMarketPurchase += onMarketPurchase;
            StoreEvents.OnMarketRefund += onMarketRefund;
            StoreEvents.OnItemPurchased += onItemPurchased;
            StoreEvents.OnGoodEquipped += onGoodEquipped;
            StoreEvents.OnGoodUnEquipped += onGoodUnequipped;
            StoreEvents.OnGoodUpgrade += onGoodUpgrade;
            StoreEvents.OnBillingSupported += onBillingSupported;
            StoreEvents.OnBillingNotSupported += onBillingNotSupported;
            StoreEvents.OnMarketPurchaseStarted += onMarketPurchaseStarted;
            StoreEvents.OnItemPurchaseStarted += onItemPurchaseStarted;
            StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
            StoreEvents.OnGoodBalanceChanged += onGoodBalanceChanged;
            StoreEvents.OnMarketPurchaseCancelled += onMarketPurchaseCancelled;
            StoreEvents.OnRestoreTransactionsStarted += onRestoreTransactionsStarted;
            StoreEvents.OnRestoreTransactionsFinished += onRestoreTransactionsFinished;
            StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;
            StoreEvents.OnUnexpectedStoreError += onUnexpectedStoreError;

#if UNITY_ANDROID && !UNITY_EDITOR
            StoreEvents.OnIabServiceStarted += onIabServiceStarted;
            StoreEvents.OnIabServiceStopped += onIabServiceStopped;
#endif
        }

        ///// <summary>
        ///// Initializes StoreEvents before the game starts.
        ///// </summary>
        //void Awake()
        //{
        //    if (Instance == null)
        //    { 	// making sure we only initialize one instance.
        //        Instance = this;
        //        gameObject.name = "StoreEventHandler";
        //        GameObject.DontDestroyOnLoad(this.gameObject);
        //    }
        //    else
        //    {	// Destroying unused instances.
        //        GameObject.Destroy(this.gameObject);
        //    }
        //}

        void Start()
        {
            mCtrl = FindObjectOfType<MenuController>();

        }


        void OnDestroy()
        {
            StoreEvents.OnMarketPurchase -= onMarketPurchase;
            StoreEvents.OnMarketRefund -= onMarketRefund;
            StoreEvents.OnItemPurchased -= onItemPurchased;
            StoreEvents.OnGoodEquipped -= onGoodEquipped;
            StoreEvents.OnGoodUnEquipped -= onGoodUnequipped;
            StoreEvents.OnGoodUpgrade -= onGoodUpgrade;
            StoreEvents.OnBillingSupported -= onBillingSupported;
            StoreEvents.OnBillingNotSupported -= onBillingNotSupported;
            StoreEvents.OnMarketPurchaseStarted -= onMarketPurchaseStarted;
            StoreEvents.OnItemPurchaseStarted -= onItemPurchaseStarted;
            StoreEvents.OnCurrencyBalanceChanged -= onCurrencyBalanceChanged;
            StoreEvents.OnGoodBalanceChanged -= onGoodBalanceChanged;
            StoreEvents.OnMarketPurchaseCancelled -= onMarketPurchaseCancelled;
            StoreEvents.OnRestoreTransactionsStarted -= onRestoreTransactionsStarted;
            StoreEvents.OnRestoreTransactionsFinished -= onRestoreTransactionsFinished;
            StoreEvents.OnSoomlaStoreInitialized -= onSoomlaStoreInitialized;
            StoreEvents.OnUnexpectedStoreError -= onUnexpectedStoreError;
        }

        /// <summary>
        /// Handles unexpected errors with error code.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public void onUnexpectedStoreError(int errorCode)
        {
            mCtrl.ShowModalWindow("Oops!", errorCode.ToString());
            SoomlaUtils.LogError("StoreEventHandler", "error with code: \n" + errorCode);
        }

        /// <summary>
        /// Handles a market purchase event.
        /// </summary>
        /// <param name="pvi">Purchasable virtual item.</param>
        /// <param name="purchaseToken">Purchase token.</param>
        public void onMarketPurchase(PurchasableVirtualItem pvi, string payload, Dictionary<string, string> extra)
        {
            mCtrl.ShowModalWindow("Success!", "You have successfully purchased the \n" + pvi.Name.ToString());
        }

        /// <summary>
        /// Handles a market refund event.
        /// </summary>
        /// <param name="pvi">Purchasable virtual item.</param>
        public void onMarketRefund(PurchasableVirtualItem pvi)
        {
            mCtrl.ShowModalWindow("Refunded!", pvi.ToString() + "\n has been refunded successfully!");

        }

        /// <summary>
        /// Handles an item purchase event.
        /// </summary>
        /// <param name="pvi">Purchasable virtual item.</param>
        public void onItemPurchased(PurchasableVirtualItem pvi, string payload)
        {
            mCtrl.ShowModalWindow("Success!", "You have successfully purchased the \n" + pvi.Name);
            mCtrl.UpdateUI();
        }

        /// <summary>
        /// Handles a good equipped event.
        /// </summary>
        /// <param name="good">Equippable virtual good.</param>
        public void onGoodEquipped(EquippableVG good)
        {

        }

        /// <summary>
        /// Handles a good unequipped event.
        /// </summary>
        /// <param name="good">Equippable virtual good.</param>
        public void onGoodUnequipped(EquippableVG good)
        {

        }

        /// <summary>
        /// Handles a good upgraded event.
        /// </summary>
        /// <param name="good">Virtual good that is being upgraded.</param>
        /// <param name="currentUpgrade">The current upgrade that the given virtual
        /// good is being upgraded to.</param>
        public void onGoodUpgrade(VirtualGood good, UpgradeVG currentUpgrade)
        {

        }

        /// <summary>
        /// Handles a billing supported event.
        /// </summary>
        public void onBillingSupported()
        {

        }

        /// <summary>
        /// Handles a billing NOT supported event.
        /// </summary>
        public void onBillingNotSupported()
        {

        }

        /// <summary>
        /// Handles a market purchase started event.
        /// </summary>
        /// <param name="pvi">Purchasable virtual item.</param>
        public void onMarketPurchaseStarted(PurchasableVirtualItem pvi)
        {

        }

        /// <summary>
        /// Handles an item purchase started event.
        /// </summary>
        /// <param name="pvi">Purchasable virtual item.</param>
        public void onItemPurchaseStarted(PurchasableVirtualItem pvi)
        {

        }

        /// <summary>
        /// Handles an item purchase cancelled event.
        /// </summary>
        /// <param name="pvi">Purchasable virtual item.</param>
        public void onMarketPurchaseCancelled(PurchasableVirtualItem pvi)
        {
            mCtrl.ShowModalWindow("Cancelled", "The purchase has been cancelled.");
        }

        /// <summary>
        /// Handles a currency balance changed event.
        /// </summary>
        /// <param name="virtualCurrency">Virtual currency whose balance has changed.</param>
        /// <param name="balance">Balance of the given virtual currency.</param>
        /// <param name="amountAdded">Amount added to the balance.</param>
        public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded)
        {
            mCtrl.UpdateUI();
        }

        /// <summary>
        /// Handles a good balance changed event.
        /// </summary>
        /// <param name="good">Virtual good whose balance has changed.</param>
        /// <param name="balance">Balance.</param>
        /// <param name="amountAdded">Amount added.</param>
        public void onGoodBalanceChanged(VirtualGood good, int balance, int amountAdded)
        {

        }

        /// <summary>
        /// Handles a restore Transactions process started event.
        /// </summary>
        public void onRestoreTransactionsStarted()
        {
            
        }

        /// <summary>
        /// Handles a restore transactions process finished event.
        /// </summary>
        /// <param name="success">If set to <c>true</c> success.</param>
        public void onRestoreTransactionsFinished(bool success)
        {
            mCtrl.ShowModalWindow("Restored Transactions", "All previous transactions have been restored successfully!");
        }

        /// <summary>
        /// Handles a store controller initialized event.
        /// </summary>
        public void onSoomlaStoreInitialized()
        {

        }

#if UNITY_ANDROID && !UNITY_EDITOR
		public void onIabServiceStarted() {

		}
		public void onIabServiceStopped() {

		}
#endif

    }
}
