using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LinearInventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public Vector2 scr;

    public static int money = 300;
    public Vector2 scrollPos;

    public string sortType = "ALL";

    public bool invFilterOptions;

    [Header("Art")]
    public GUISkin invSkin;
    public GUIStyle titleStyle;

    public Transform dropLocation;
    [System.Serializable]
    public struct EquippedItems
    {
        public string slotType;
        public Transform location;
        public GameObject equippedItem;
    };

    public EquippedItems[] equippedItems;

    #endregion

    void Start()
    {
        
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(3));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(601));
        inv.Add(ItemData.CreateItem(600));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(402));
        inv.Add(ItemData.CreateItem(502));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(100));
        
        //showInv = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory") && !PauseMenu.isPaused)
        {
            showInv = !showInv;
            if (showInv)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                selectedItem = null;
            }
        }

        if (Input.GetKey(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(UnityEngine.Random.Range(0, 3)));
        }

        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            selectedItem.Amount++;
        }


    }

    void OnGUI()
    {
        if (showInv && !PauseMenu.isPaused)
        {
            scr = new Vector2(Screen.width / 16, Screen.height / 9);

            GUI.skin = invSkin;
            /*for (int i = 0; i < inv.Count; i++)
            {
                if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                {
                    selectedItem = inv[i];
                }
            }*/
            


            if (GUI.Button(new Rect(4f * scr.x , 6.75f * scr.y, 1.5f *scr.x, 0.25f * scr.y),"Filter"))
            {
                invFilterOptions = !invFilterOptions;

            }
            

            if(invFilterOptions) // dropdown
            {
                int x = 1;
                foreach (ItemTypes type in Enum.GetValues(typeof(ItemTypes)))
                {
                    if (GUI.Button(new Rect(5.5f * scr.x, (6.75f + (x * 0.25f)) * scr.y, 1.5f * scr.x, 0.25f * scr.y), type.ToString()))
                    {
                        sortType = type.ToString();
                    }
                    x++;
                }
                
                /*
                if (GUI.Button(new Rect(5.5f * scr.x, 6.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "All"))
                {
                    sortType = "ALL";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 7f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Armour"))
                {
                    sortType = "Armour";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 7.25f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Weapons"))
                {
                    sortType = "Weapon";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 7.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Potions"))
                {
                    sortType = "Potion";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 7.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Food"))
                {
                    sortType = "Food";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 8f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Ingredients"))
                {
                    sortType = "Ingredient";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 8.25f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Craftable"))
                {
                    sortType = "Craftable";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 8.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Quest"))
                {
                    sortType = "Quest";
                }
                if (GUI.Button(new Rect(5.5f * scr.x, 8.75f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Misc"))
                {
                    sortType = "Misc";
                }
                */
            }
            DisplayInv();
            GUI.skin = null;
            

            if (selectedItem == null)
            {
                return;
            }
            else
            {
                UseItem();
            }

        }
    }

    void DisplayInv()
    {
        //if we have a filter type selected 
        if (!(sortType == "ALL" || sortType == "" || sortType == "All"))
        {
            ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);

            int a = 0; // amount of this category type
            int s = 0; // new slot position;

            for (int i = 0; i < inv.Count; i++)
            {
                if(inv[i].ItemType == type)
                {
                    a++;
                }
            }

            if (a <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }
                    
                }
            }
            else
            {
                // our move position of scroll window
                scrollPos =
                    // the start of our scroll view
                    GUI.BeginScrollView(
                    //our position and size of our window
                    new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y),
                    // current position in the scrollview
                    scrollPos,
                    //viewable area
                    new Rect(0, 0, 0, a * (0.25f * scr.y)),
                    //can we see our Horizontal bar?
                    false,
                    // vertical bar
                    true);

                #region Scrollable Space

                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, s * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                        }
                        s++;
                    }
                }

                #endregion
                GUI.EndScrollView();
            }

        }
            //All items are displayed
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
            }
            else // we have more items than screen height
            {
                // our move position of scroll window
                scrollPos =
                    // the start of our scroll view
                    GUI.BeginScrollView(
                    //our position and size of our window
                    new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y),
                    // current position in the scrollview
                    scrollPos,
                    //viewable area
                    new Rect(0, 0, 0, inv.Count * (0.25f * scr.y)),
                    //can we see our Horizontal bar?
                    false,
                    // vertical bar
                    true);

                #region Scrollable Space

                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
                
                #endregion
                GUI.EndScrollView();
            }
        }
    }

    void UseItem()
    {

        GUI.Box(new Rect(4f * scr.x, 0.25f * scr.y, 3 * scr.x, 0.25f * scr.y), selectedItem.Name,titleStyle);
        GUI.skin = invSkin;
        GUI.Box(new Rect(4f * scr.x, 0.5f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.IconName);
        GUI.Box(new Rect(4f * scr.x, 3.5f * scr.y, 3 * scr.x, 3 * scr.y), selectedItem.Description + "\nAmount: " + selectedItem.Amount + "\nPrice: $" + selectedItem.Value);
        

        switch (selectedItem.ItemType)
        {
            case ItemTypes.Armour:
                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Wear"))
                {

                }
                

                break;
            case ItemTypes.Weapon:

                if (equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name)
                {
                    if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Equip"))
                    {
                        
                        if (equippedItems[1].equippedItem != null)
                        {
                            Destroy(equippedItems[1].equippedItem);
                        }

                        equippedItems[1].equippedItem = Instantiate(selectedItem.MeshName, equippedItems[1].location);
                        equippedItems[1].equippedItem.name = selectedItem.Name;
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "UnEquip"))
                    {
                        Destroy(equippedItems[1].equippedItem);
                        equippedItems[1].equippedItem = null;
                    }
                }

                
                break;
            case ItemTypes.Potion:
                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Drink"))
                {

                }
                
                break;            
            
            case ItemTypes.Food:
                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Eat"))
                {

                }
                
                break;
            case ItemTypes.Ingredient:
                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Use"))
                {

                }
               
                break;
            case ItemTypes.Craftable:
                if (GUI.Button(new Rect(4 * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Use"))
                {

                }
               
                break;
            
            default:
                break;
        }
        if (GUI.Button(new Rect(5.5f * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Discard"))
        {
            // checked if item is equiped
            for (int i = 0; i < equippedItems.Length; i++)
            {
                if (equippedItems[i].equippedItem != null && selectedItem.Name == equippedItems[i].equippedItem.name)
                {
                    //if so destroy from scene
                    Destroy(equippedItems[i].equippedItem);
                }
            }
            
            // spawn item a droplocation
            GameObject itemToDrop = Instantiate(selectedItem.MeshName, dropLocation.position, Quaternion.identity);
            // apply gravity and make sure its nambed correctly
            itemToDrop.name = selectedItem.Name;
            itemToDrop.AddComponent<Rigidbody>().useGravity = true;
            
            // is the amount > 1
            if (selectedItem.Amount > 1) // if so reduce from list
            {
                selectedItem.Amount--;
            }
            else // else remove from list
            {
                inv.Remove(selectedItem);
                selectedItem = null;
                return;
            }
            
        }
    }
}
