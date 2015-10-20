using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;

namespace Soomla.Store
{
    public class CatAndMouseStore : IStoreAssets
    {
        
        public int GetVersion()
        {
            return 0;
        }

        public VirtualCurrency[] GetCurrencies()
        {
            return new VirtualCurrency[] { COIN_CURRENCY, GEM_CURRENCY };
        }

        public VirtualCurrencyPack[] GetCurrencyPacks()
        {
            return new VirtualCurrencyPack[] { GEM_PACK_1_ITEM, GEM_PACK_2_ITEM, GEM_PACK_3_ITEM, COIN_PACK_1_ITEM, COIN_PACK_2_ITEM, COIN_PACK_3_ITEM };
        }

        public VirtualGood[] GetGoods()
        {
            return new VirtualGood[] { UNLOCKABLE_ITEM_1, UNLOCKABLE_ITEM_2, UNLOCKABLE_ITEM_3, UNLOCKABLE_ITEM_4};
        }

        public VirtualCategory[] GetCategories()
        {
            return new VirtualCategory[] { };
        }


        // STORE THE GPLAY CURRENCY HERE
        public const string COIN_CURRENCY_ID = "currency_coin";
        public const string GEM_CURRENCY_ID = "currency_gem";

        //STORE THE VC PACKS HERE
        public const string COIN_PACK_1_ID = "coin_pack_1";
        public const string COIN_PACK_2_ID = "coin_pack_2";
        public const string COIN_PACK_3_ID = "coin_pack_3";

        public const string GEM_PACK_1_ID = "android.test.purchased";
        public const string GEM_PACK_2_ID = "android.test.canceled";
        public const string GEM_PACK_3_ID = "android.test.refunded";

        

        //STORE THE LIFETIME VIRTUAL GOODS HERE
        public static string NO_ADS_PRODUCT_ID = "remove_ads";



        /** Virtual Currencies **/

        public static VirtualCurrency COIN_CURRENCY = new VirtualCurrency(
            "Coin",                               // Name
            "Coin currency",                      // Description
            COIN_CURRENCY_ID                 // Item ID
            );

        public static VirtualCurrency GEM_CURRENCY = new VirtualCurrency(
            "Gems",										// name
            "Gem Currency",								// description
            GEM_CURRENCY_ID						// item id
            );

        // VIRTUAL CURRENCY PACKS PURCHASED WITH CASH (GEMS)
        public static VirtualCurrencyPack GEM_PACK_1_ITEM = new VirtualCurrencyPack(
            "SMALL GEM PACK",                                  		// name
            "Test purchase of an item",                       	// description
            GEM_PACK_1_ID,                                   	// item id
            1000,												// number of currencies in the pack
            GEM_CURRENCY_ID,                        		// the currency associated with this pack
            new PurchaseWithMarket(GEM_PACK_1_ID, 1.990)
            );

        public static VirtualCurrencyPack GEM_PACK_2_ITEM = new VirtualCurrencyPack(
            "MEDIUM GEM PACK",                                  		// name
            "Test purchase of an item",                       	// description
            GEM_PACK_2_ID,                                   	// item id
            1000,												// number of currencies in the pack
            GEM_CURRENCY_ID,                        		// the currency associated with this pack
            new PurchaseWithMarket(GEM_PACK_2_ID, 3.990)
            );

        public static VirtualCurrencyPack GEM_PACK_3_ITEM = new VirtualCurrencyPack(
            "LARGE GEM PACK",                                  		// name
            "Test purchase of an item",                       	// description
            GEM_PACK_3_ID,                                   	// item id
            1000,												// number of currencies in the pack
            GEM_CURRENCY_ID,                        		// the currency associated with this pack
            new PurchaseWithMarket(GEM_PACK_3_ID, 5.990)
            );

        // VIRTUAL CURRENCY PACKS PURCHASED WITH ANOTHER VIRTUAL CURRENCY (BUY COIN PACKS WITH GEMS)
        public static VirtualCurrencyPack COIN_PACK_1_ITEM = new VirtualCurrencyPack(
            "SHITTY COIN PACK",                                  	// name
            "Test purchase of an item",                       	// description
            COIN_PACK_1_ID,                                   	// item id
            10000,												// number of currencies in the pack
            COIN_CURRENCY_ID,                        		    // the currency associated with this pack
            new PurchaseWithVirtualItem(GEM_CURRENCY_ID, 25)
            );

        public static VirtualCurrencyPack COIN_PACK_2_ITEM = new VirtualCurrencyPack(
            "OK-ISH COIN PACK",                                  	// name
            "Test purchase of an item",                       	// description
            COIN_PACK_2_ID,                                   	// item id
            50000,												// number of currencies in the pack
            COIN_CURRENCY_ID,                        		    // the currency associated with this pack
            new PurchaseWithVirtualItem(GEM_CURRENCY_ID, 75)
            );

        public static VirtualCurrencyPack COIN_PACK_3_ITEM = new VirtualCurrencyPack(
            "FUCKTON COIN PACK",                                  	// name
            "Test purchase of an item",                       	// description
            COIN_PACK_3_ID,                                   	// item id
            150000,												// number of currencies in the pack
            COIN_CURRENCY_ID,                        		    // the currency associated with this pack
            new PurchaseWithVirtualItem(GEM_CURRENCY_ID, 150)
            );

        // An item that is purchased with virtual coins.
        public static VirtualGood UNLOCKABLE_ITEM_1 = new LifetimeVG(
            "Unlockable Item 1",                                                            // Name
            "This item is yours for as long as the game's storage doesn't change!", // Description
            "Unlockable_1",                                                            // Item ID
            new PurchaseWithVirtualItem(COIN_CURRENCY_ID, 3000)               // Purchase type
        );

        // An item that is purchased with virtual coins.
        public static VirtualGood UNLOCKABLE_ITEM_2 = new LifetimeVG(
            "Unlockable Item 2",                                                            // Name
            "This item is yours for as long as the game's storage doesn't change!", // Description
            "Unlockable_2",                                                            // Item ID
            new PurchaseWithVirtualItem(COIN_CURRENCY_ID, 8000)               // Purchase type
        );

        // An item that is purchased with virtual coins.
        public static VirtualGood UNLOCKABLE_ITEM_3 = new LifetimeVG(
            "Unlockable Item 3",                                                            // Name
            "This item is yours for as long as the game's storage doesn't change!", // Description
            "Unlockable_3",                                                            // Item ID
            new PurchaseWithVirtualItem(COIN_CURRENCY_ID, 10000)               // Purchase type
        );

        // An item that is purchased with virtual coins.
        public static VirtualGood UNLOCKABLE_ITEM_4 = new LifetimeVG(
            "Unlockable Item 4",                                                            // Name
            "This item is yours for as long as the game's storage doesn't change!", // Description
            "Unlockable_4",                                                            // Item ID
            new PurchaseWithVirtualItem(COIN_CURRENCY_ID, 12000)               // Purchase type
        );
    }
}
