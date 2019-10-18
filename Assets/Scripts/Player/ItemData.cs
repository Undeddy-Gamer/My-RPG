using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemId)
    {
        string name = "";
        string description = "";
        int amount = 0;
        int value = 0;
        int damage = 0;
        int armour = 0;
        int heal = 0;
        string iconName = "";
        string meshName = "";
        ItemTypes type = ItemTypes.Misc;

        switch (itemId)
        {
            #region Armour 0-99
            case 0:
                name = "Leather Chest Armour";
                description = "Leather armour for you chest";
                amount = 1;
                value = 50;
                damage = 0;
                armour = 6;
                heal = 0;
                iconName = "Armour/LeatherChest";
                meshName = "Armour/LeatherChest";
                type = ItemTypes.Armour;
                break;
            case 1:
                name = "Leather Boots";
                description = "Leather armour for you feet";
                amount = 1;
                value = 50;
                damage = 0;
                armour = 6;
                heal = 0;
                iconName = "Armour/LeatherBoots";
                meshName = "Armour/LeatherBoots";
                type = ItemTypes.Armour;
                break;
            case 2:
                name = "Leather Leggings";
                description = "Leather armour for you legs";
                amount = 1;
                value = 50;
                damage = 0;
                armour = 6;
                heal = 0;
                iconName = "Armour/LeatherLegs";
                meshName = "Armour/LeatherLegs";
                type = ItemTypes.Armour;
                break;
            case 3:
                name = "Iron Helmet";
                description = "";
                amount = 1;
                value = 100;
                damage = 0;
                armour = 6;
                heal = 0;
                iconName = "Armour/IronHelmet";
                meshName = "Armour/IronHelmet";
                type = ItemTypes.Armour;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "Iron Sword";
                description = "";
                amount = 1;
                value = 100;
                damage = 15;
                armour = 0;
                heal = 0;
                iconName = "Armour/IronSword";
                meshName = "Armour/IronSword";
                type = ItemTypes.Weapon;
                break;
            case 101:
                name = "Iron Axe";
                description = "";
                amount = 1;
                value = 50;
                damage = 10;
                armour = 0;
                heal = 0;
                iconName = "Armour/IronAxe";
                meshName = "Armour/IronAxe";
                type = ItemTypes.Weapon;
                break;
            case 102:
                name = "Iron Mace";
                description = "";
                amount = 1;
                value = 40;
                damage = 8;
                armour = 0;
                heal = 0;
                iconName = "Armour/IronMace";
                meshName = "Armour/IronMace";
                type = ItemTypes.Weapon;
                break;
            #endregion
            #region Potion 200-299
            case 200:
                name = "Healing Potion";
                description = "";
                amount = 1;
                value = 40;
                damage = 0;
                armour = 0;
                heal = 50;
                iconName = "Potions/Heal";
                meshName = "";
                type = ItemTypes.Potion;
                break;
            case 201:
                name = "Potion of Speed";
                description = "";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 10;
                iconName = "Potions/Speed";
                meshName = "Potions/Speed";
                type = ItemTypes.Potion;
                break;
            case 202:
                name = "Mana Potion";
                description = "";
                amount = 1;
                value = 20;
                damage = 0;
                armour = 0;
                heal = 20;
                iconName = "Potions/Mana";
                meshName = "";
                type = ItemTypes.Potion;
                break;
            #endregion
            #region Food 300-399
            case 300:
                name = "Apple";
                description = "Munchies and Crunchies";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 2;
                iconName = "Food/Apple";
                meshName = "Food/Apple";
                type = ItemTypes.Food;
                break;
            case 301:
                name = "Meat";
                description = "Mmmmmmm Yummy";
                amount = 1;
                value = 6;
                damage = 0;
                armour = 0;
                heal = 10;
                iconName = "Food/Meat";
                meshName = "Food/Meat";
                type = ItemTypes.Food;
                break;
            case 302:
                name = "Fish";
                description = "Mmmmmmm Yummy";
                amount = 1;
                value = 4;
                damage = 0;
                armour = 0;
                heal = 5;
                iconName = "Food/Fish";
                meshName = "Food/Fish";
                type = ItemTypes.Food;
                break;
            #endregion
            #region Ingredient 400-499
            case 400:
                name = "Red Mushroom";
                description = "";
                amount = 1;
                value = 3;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredients/MushroomRed";
                meshName = "Ingredients/MushroomRed";
                type = ItemTypes.Ingredient;
                break;
            case 401:
                name = "Blue Mushroom";
                description = "";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredients/MushroomBlue";
                meshName = "Ingredients/MushroomBlue";
                type = ItemTypes.Ingredient;
                break;
            case 402:
                name = "Yellow Flower";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredients/FlowerYellow";
                meshName = "Ingredients/FlowerYellow";
                type = ItemTypes.Ingredient;
                break;
            #endregion
            #region Craftable 500-599
            case 500:
                name = "Blue Gem";
                description = "";
                amount = 1;
                value = 15;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/GemBlue";
                meshName = "Craftable/GemBlue";
                type = ItemTypes.Craftable;
                break;
            case 501:
                name = "Yellow Gem";
                description = "";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/GemYellow";
                meshName = "Craftable/GemYellow";
                type = ItemTypes.Craftable;
                break;
            case 502:
                name = "Onyx";
                description = "";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/Onyx";
                meshName = "Craftable/Onyx";
                type = ItemTypes.Craftable;
                break;
            #endregion
            #region Quest 600-699
            case 600:
                name = "Lightning Peal";
                description = "";
                amount = 1;
                value = 500;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Quest/PearlLightning";
                meshName = "Quest/PearlLightning";
                type = ItemTypes.Quest;
                break;
            case 601:
                name = "4 Leaf Clover";
                description = "";
                amount = 1;
                value = 100;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Quest/FourLeafClover";
                meshName = "Quest/FourLeafClover";
                type = ItemTypes.Quest;
                break;
            case 602:
                name = "Funny Book";
                description = "";
                amount = 1;
                value = 100;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Quest/BookFunny";
                meshName = "Quest/BookFunny";
                type = ItemTypes.Quest;
                break;
            #endregion
            #region Misc 700-799
            case 700:
                name = "Copper Coins";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/CoinCopper";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            case 701:
                name = "Silver Coins";
                description = "";
                amount = 1;
                value = 10;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/CoinSilver";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            case 702:
                name = "Gold Coins";
                description = "";
                amount = 1;
                value = 100;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/CoinGold";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            default:
                itemId = 0;
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
        }
        Item temp = new Item
        {
            ID = itemId,
            Name = name,
            Description = description,
            Value = value,
            Amount = amount,
            Damage = damage,
            Armour = armour,
            Heal = heal,
            IconName = Resources.Load("Icons/" + iconName) as Texture2D,
            MeshName = Resources.Load("Prefabs/" + meshName) as GameObject,
            ItemType = type
        };
        return temp;
    }
}
