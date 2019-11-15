using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : MonoBehaviour
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

    public Transform dropLocation;
    [System.Serializable]
    public struct EquippedItems
    {
        public string slotType;
        public Transform location;
        public GameObject equippedItem;
    };

    public EquippedItems[] equippedItems;

    public GameObject testObject;

    #endregion


    // Start is called before the first frame update
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

        //GameObject newObj; // Create item instance
        
    }

    // Update is called once per frame
    void Update()
    {   

        // check if inventory button is hit
        if (Input.GetButtonDown("Inventory") && !PauseMenu.isPaused)
        {
            showInv = !showInv;
            if (showInv)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                ShowScrollInventory();
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                selectedItem = null;
            }
        }

        //test key to add inventory items
        if (Input.GetKey(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(UnityEngine.Random.Range(0, 3)));
        }
        //test key to add more of the same item (quanity)
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            selectedItem.Amount++;
        }


    }
    

    private void ShowScrollInventory()
    {       

        if (showInv && !PauseMenu.isPaused)
        {
            //If A filter is selected
            if (!(sortType == "ALL" || sortType == "" || sortType == "All"))
            {
                ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);
                
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].ItemType == type)
                    {
                        AddItem(inv[i]);
                    }
                }
            }
            //All items are displayed
            else
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    AddItem(inv[i]);
                }
            }
        }
    }

    private void AddItem(Item theItem)
    {
        // create the button
        Button itemButton = testObject.GetComponent<Button>();
        // attach a listener to the button (function that it will activate
        itemButton.onClick.AddListener(() => SelectItem(theItem));
        

        //if we have more than 1 of the item lets display a count on the button too
        if (theItem.Amount > 1)
        {
            itemButton.GetComponentInChildren<Text>().text = theItem.Name + " (" + theItem.Amount + ")";
        }
        else // set the text of the button  to name only
        {            
            itemButton.GetComponentInChildren<Text>().text = theItem.Name;
        }
        
        Button tempButton = (Button)Instantiate(itemButton, transform);
    }

    public void SelectItem(Item theItem)
    {
        selectedItem = theItem;
    }

    private void ShowItem(Item theItem)
    {

    }

   

}
