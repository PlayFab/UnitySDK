using UnityEngine;

namespace PlayFab.Examples.Server
{
    /// <summary>
    /// This example will have poor performance for a real title with lots of items.
    /// However, it's a very consise example for a test-title, with a small number of CatalogItems.
    /// 
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Inventory Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// </summary>
    public class S_InventoryExampleGui : PfExampleGui
    {
        void Awake()
        {
            InventoryExample.SetUp();
        }

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            bool charsValid = isLoggedIn && PfSharedModelEx.characterIds.Count > 0;
            int colIndex;

            Button(isLoggedIn, rowIndex, 0, "Refresh User Inv", InventoryExample.GetUserInventory);
            TextField(isLoggedIn, rowIndex, 1, ref PfSharedModelEx.userInvDisplay);
            rowIndex++;
            // Purchase Items
            TextField(isLoggedIn, rowIndex, 0, "Grant User Item:");
            if (PfSharedModelEx.serverCatalog != null)
            {
                colIndex = 1;
                foreach (var catalogPair in PfSharedModelEx.serverCatalog)
                    Button(isLoggedIn, rowIndex, colIndex++, catalogPair.Value.DisplayName, InventoryExample.GrantUserItem(catalogPair.Key));
            }
            rowIndex++;
            // Move User Items to characters
            for (int charIndex = 0; PfSharedModelEx.serverUserItems != null && charIndex < PfSharedModelEx.characterIds.Count; charIndex++)
            {
                string eachCharacterId = PfSharedModelEx.characterIds[charIndex];
                PfCharInv tempCharater;
                if (!PfSharedModelEx.serverCharInventories.TryGetValue(eachCharacterId, out tempCharater))
                    continue;
                PfInvServerChar eachCharacter = tempCharater as PfInvServerChar;
                if (eachCharacter == null || eachCharacter.inventory == null)
                    continue;

                TextField(eachCharacter != null, rowIndex, 0, "Move to " + eachCharacter.characterName + ":");
                for (int i = 0; i < PfSharedModelEx.serverUserItems.Count; i++)
                    Button(eachCharacter != null, rowIndex, i + 1, PfSharedModelEx.serverUserItems[i].DisplayName, eachCharacter.MoveToCharFromUser(PfSharedModelEx.serverUserItems[i].ItemInstanceId));
                rowIndex++;
            }
            // Revoke User Items
            TextField(isLoggedIn, rowIndex, 0, "Revoke:");
            if (PfSharedModelEx.serverUserItems != null)
                for (int i = 0; i < PfSharedModelEx.serverUserItems.Count; i++)
                    Button(isLoggedIn, rowIndex, i + 1, PfSharedModelEx.serverUserItems[i].DisplayName, InventoryExample.RevokeUserItem(PfSharedModelEx.serverUserItems[i].ItemInstanceId));
            rowIndex++;
            rowIndex++;

            for (int charIndex = 0; charIndex < PfSharedModelEx.characterIds.Count; charIndex++)
            {
                string eachCharacterId = PfSharedModelEx.characterIds[charIndex];
                PfCharInv tempCharater;
                if (!PfSharedModelEx.serverCharInventories.TryGetValue(eachCharacterId, out tempCharater))
                    continue;
                PfInvServerChar eachCharacter = tempCharater as PfInvServerChar;
                if (eachCharacter == null || eachCharacter.inventory == null)
                    continue;

                Button(charsValid, rowIndex, 0, "Refresh " + eachCharacter.characterName + " Inv", eachCharacter.GetInventory);
                TextField(charsValid, rowIndex, 1, eachCharacter.inventoryDisplay);
                rowIndex++;
                // Grant Char Items
                TextField(charsValid, rowIndex, 0, "Grant " + eachCharacter.characterName + " Item:");
                if (PfSharedModelEx.serverCatalog != null)
                {
                    colIndex = 1;
                    foreach (var catalogPair in PfSharedModelEx.serverCatalog)
                        Button(charsValid, rowIndex, colIndex++, catalogPair.Value.DisplayName, eachCharacter.GrantCharacterItem(catalogPair.Key));
                }
                rowIndex++;
                // Move Character Items to User
                TextField(charsValid, rowIndex, 0, "Move to User:");
                for (int i = 0; i < eachCharacter.inventory.Count; i++)
                    Button(charsValid, rowIndex, i + 1, eachCharacter.inventory[i].DisplayName, eachCharacter.MoveToUser(eachCharacter.inventory[i].ItemInstanceId));
                rowIndex++;
                // Revoke Character Items
                TextField(charsValid, rowIndex, 0, "Revoke:");
                for (int i = 0; i < eachCharacter.inventory.Count; i++)
                    Button(charsValid, rowIndex, i + 1, eachCharacter.inventory[i].DisplayName, eachCharacter.RevokeItem(eachCharacter.inventory[i].ItemInstanceId));
                rowIndex++;
                rowIndex++;
            }
        }
        #endregion Unity GUI
    }
}
