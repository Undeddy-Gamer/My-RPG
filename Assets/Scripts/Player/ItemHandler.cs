using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{

    public int itemId = 0;
    public ItemTypes itemType;
    public int amount = 1;

    public void OnCollection()
    {
        if (itemType == ItemTypes.Money) // is it cash
        {
            LinearInventory.money += amount;
        }
        else if (itemType == ItemTypes.Craftable || itemType == ItemTypes.Food || itemType == ItemTypes.Ingredient || itemType == ItemTypes.Potion) // is it stackable
        {
            int found = 0;
            int addindex = 0;

            for (int i = 0; i < LinearInventory.inv.Count; i++)
            {
                if (itemId == LinearInventory.inv[i].ID)
                {
                    found = 1;
                    addindex = i;
                    break;
                }
            }

            if (found == 1)
            {
                LinearInventory.inv[addindex].Amount += amount;
            }
            else
            {
                Item newItem = ItemData.CreateItem(itemId);
                if (amount > 1)
                {
                    newItem.Amount = amount;
                }
                LinearInventory.inv.Add(newItem);                
            }
        }
        else  // otherwise just add new item
            LinearInventory.inv.Add(ItemData.CreateItem(itemId));

        Destroy(gameObject);
    }

}
