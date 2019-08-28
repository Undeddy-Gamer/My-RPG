using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerSaveToBinary
{
    
    public static void SavePlayerData(PlayerHandler player)
    {
        //Refrence a Binary Formatter
        BinaryFormatter formatter = new BinaryFormatter();
        
        //Location to Save
        string path = Application.persistentDataPath + "/" + player.name + ".god";

        //Create file at file path
        FileStream stream = new FileStream(path, FileMode.Create);

        //What Data to write to the file
        PlayerDataToSave data = new PlayerDataToSave(player);        

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static PlayerDataToSave LoadData(PlayerHandler player)
    {
        string path = Application.persistentDataPath + "/" + player.name + ".god";

        if (File.Exists(path))
        {
            //Get our binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            // and read the data from the path
            FileStream stream = new FileStream(path, FileMode.Open);
            //set the data from what it is back to usable variables
            PlayerDataToSave data = formatter.Deserialize(stream) as PlayerDataToSave;
            //we are done
            stream.Close();
            //send usable data back to the PlayerDataToSave Script
            return data;
        }
        else
        {
            return null;
        }
    }

}
