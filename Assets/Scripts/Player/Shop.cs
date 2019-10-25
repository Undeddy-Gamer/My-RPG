using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public bool showShop;
    public int[] itemsToSpawn;
    public List<Item> shopInv = new List<Item>();
    public Item selectedShopItem;

    public bool randomItems = true;
    public int randomItemCount = 3;


    private void Start()
    {

        if (randomItems)
        {
            for (int i = 0; i < randomItemCount - 1; i++)
            {
                itemsToSpawn[i] = Random.Range(0, 4);
                shopInv.Add(ItemData.CreateItem(itemsToSpawn[i]));
            }
        }

        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            shopInv.Add(ItemData.CreateItem(itemsToSpawn[i]));
        }


    }

    private void OnGUI()
    {
        if (showShop)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            GUI.Box(new Rect(6.5f * scr.x, scr.y, 3* scr.x, 0.25f*scr.y), "$" + LinearInventory.money);

            for (int i = 0; i < shopInv.Count; i++)
            {
                if (GUI.Button(new Rect(12.75f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), shopInv[i].Name))
                {
                    selectedShopItem = shopInv[i];
                }
            }

            if (selectedShopItem == null)
            {
                return;
            }
            else
            {
                int cost = (int)System.Math.Round(selectedShopItem.Value * 1.25f, 0);
                
                GUI.Box(new Rect(9.5f * scr.x, scr.y, 3 * scr.x, 0.25f * scr.y), "$" + cost);

                if (LinearInventory.money > cost)
                {
                    if (GUI.Button(new Rect(12.5f * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Purchase"))
                    {
                        LinearInventory.inv.Add(ItemData.CreateItem(selectedShopItem.ID));
                        shopInv.Remove(selectedShopItem);
                        selectedShopItem = null;

                        LinearInventory.money -= cost;
                    }
                }
                

            }

        }

    }
}
