[System.Serializable]

//Serialisation is the automatic process of tranforming data structures or object states into a format that unity can store and reconstruct later

// Serialization is the process of converting an object into a stream of bytes to store the object or transmit it to memory, a database, or a file.  Its best main

public class PlayerDataToSave 
{
    //Data to get from game
    public string playerName;
    public int level;

    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float pX, pY, pZ;
    public float rX, rY, rZ, rW;
    
    public PlayerDataToSave(PlayerHandler player)
    {

        playerName = player.name;
        level = 0;

        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = player.curStamina;

        pX = player.transform.position.x;
        pY = player.transform.position.y;
        pZ = player.transform.position.z;

        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;

    }

}
