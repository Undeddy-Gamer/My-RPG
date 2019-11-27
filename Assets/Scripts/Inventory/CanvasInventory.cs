using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    private Item selectedItem;
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

    public GameObject inventoryPanel;
    public GameObject buttonObject;
    public GameObject invDisplayPanel;

    public Button btnUse;
    public Button btnDrop;
    

    public Text txtTitle;
    public Text txtDesc;
    public Text txtQuantity;
    public Text txtValue;
    public Text txtAttributes;
    public Image invItemImage;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //Testing stuff
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

        inventoryPanel.SetActive(false);
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
                ShowScrollInventory();
                if (selectedItem != null)
                {
                    SelectItem(selectedItem);
                }
                
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                inventoryPanel.SetActive(true);
                
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                inventoryPanel.SetActive(false);
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
        // create a new button from prefab
        GameObject tempButton = Instantiate(buttonObject, invDisplayPanel.transform);
        Button itemButton = tempButton.GetComponent<Button>();
        

        //if we have more than 1 of the item lets display a count on the button too
        if (theItem.Amount > 1)
        {
            itemButton.GetComponentInChildren<Text>().text = theItem.Name + " (" + theItem.Amount + ")";
        }
        else // set the text of the button to name only
        {            
            itemButton.GetComponentInChildren<Text>().text = theItem.Name;
        }

        // attach a listener to the button (function that it will activate when clicked)        
        itemButton.onClick.AddListener(delegate { SelectItem(theItem); });        
    }

    public void SelectItem(Item theItem)
    {
        //set the selected Item
        selectedItem = theItem;
        Debug.Log("Show Item: " + theItem.Name);

        txtTitle.text = theItem.Name;
        txtDesc.text = theItem.Description;
        txtValue.text = "$" + theItem.Value.ToString();
        txtQuantity.text = "(" + theItem.Amount.ToString() + ")";       

        string attribs = "Attributes: ";
        bool addComma = false;

        if (theItem.Armour > 0)
        {
            attribs += "Armour(+" + theItem.Armour + ")";
            addComma = true;
        }

        if (theItem.Damage > 0)
        {
            if (addComma)
            {
                attribs += ", ";
            }
            attribs += "Damage(+" + theItem.Damage + ")";
        }

        if (theItem.Heal > 0)
        {
            if (addComma)
            {
                attribs += ", ";
            }
            attribs += "Health(+" + theItem.Heal + ")";
            addComma = true;
        }

        txtAttributes.text = attribs;
                
        // Set the sprite of the UI Image to the Texture2D in Item data (needs to be converted)
        invItemImage.sprite = Sprite.Create(theItem.IconName, new Rect(0, 0, theItem.IconName.width, theItem.IconName.height), new Vector2(0.5f, 0.5f));
        //Set the Image 'gameobject' active
        invItemImage.gameObject.SetActive(true);


        switch (selectedItem.ItemType)
        {
            case ItemTypes.Armour:
                // run equip equipment function (0 for Armour)
                EquipItem(selectedItem, 0);
                break;

            case ItemTypes.Weapon:
                // run equip equipment function (1 for Weapons)
                EquipItem(selectedItem, 1);
                break;

            case ItemTypes.Potion:

                break;
          //case etc
          //    ...... prob should be some kind of loop anyway
            default:

                btnDrop.gameObject.SetActive(false);
                btnUse.gameObject.SetActive(false);
                break;
        }

        //ShowItem(theItem);
    }

    void EquipItem(Item selectedItem, int placement)
    {

        if (equippedItems[placement].equippedItem == null || selectedItem.Name != equippedItems[placement].equippedItem.name)
        {
            btnUse.GetComponentInChildren<Text>().text = "Equip";
            btnDrop.enabled = true;
            
            if (equippedItems[placement].equippedItem != null)
            {
                Destroy(equippedItems[placement].equippedItem);
            }

            equippedItems[placement].equippedItem = Instantiate(selectedItem.MeshName, equippedItems[placement].location);
            equippedItems[placement].equippedItem.name = selectedItem.Name;
        }
        else
        {
            btnUse.GetComponentInChildren<Text>().text = "Unequip";
            Destroy(equippedItems[placement].equippedItem);
            equippedItems[placement].equippedItem = null;
            btnDrop.enabled = false;
        }

        
    }
   

}
