using UnityEngine;
public class Item
{
    #region Variables
    //id of the item for programmers and developers
    private int _id;
    //Desplay name and description for players
    private string _name;
    private string _description;
    //Amount of items of that type
    private int _amount;
    //Buy and Sell value
    private int _value;
    //Basic Stats
    private int _damage;
    private int _armour;
    private int _heal;
    private bool _stackable;
    //Display Icon and Mesh
    private Texture2D _iconName;
    private GameObject _meshName;
    //Type of item...for item use
    private ItemTypes _type;
    #endregion
    #region Properties

    // Make the attributes publically available to change/get
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }

    public bool Stackable
    {
        get { return _stackable; }
        set { _stackable = value; }
    }
    public Texture2D IconName
    {
        get { return _iconName; }
        set { _iconName = value; }
    }
    public GameObject MeshName
    {
        get { return _meshName; }
        set { _meshName = value; }
    }
    public ItemTypes ItemType
    {
        get { return _type; }
        set { _type = value; }
    }
    #endregion
}

//Enum of Item types to make it easier to differentiate later
public enum ItemTypes
{
    Armour,
    Weapon,
    Potion,
    Money,
    Quest,
    Food,
    Ingredient,
    Craftable,
    Misc
}