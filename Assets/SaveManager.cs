using UnityEngine;

/// <summary>Manages data for persistance between play sessions.</summary>
public class SaveManager : ScriptableObject 
{
    public int playerCoin = 0;

    public string playerLevel = "Level1";

    private static string playerCoinKey = "PLAYER_COIN";
    private static string playerLevelKey = "PLAYER_LEVEL";

    public void IncreasePlayerCoin(){
        playerCoin++;
        PlayerPrefs.SetInt(playerCoinKey, playerCoin);
    }

    public void SetPlayerLevel(string level){
        PlayerPrefs.SetString(playerLevelKey, level);
    }

    /// <summary>Save to the PlayerPrefs file.</summary>
    public void Save()
    {
        // Manually save the PlayerPrefs file to disk, in case we experience a crash
        PlayerPrefs.Save();
    }

    /// <summary>Load from the PlayerPrefs file.</summary>
    public void Load()
    {
        // If the PlayerPrefs file currently has a value registered to the playerCoinKey, 
        if (PlayerPrefs.HasKey(playerCoinKey))
        {
            // load playerCoin from the PlayerPrefs file.
            playerCoin = PlayerPrefs.GetInt(playerCoinKey);
        }

        if (PlayerPrefs.HasKey(playerLevelKey))
        {
            // load playerCoin from the PlayerPrefs file.
            playerLevel = PlayerPrefs.GetString(playerLevelKey);
        }
    }

    /// <summary>Deletes all values from the PlayerPrefs file.</summary>
    public void Delete()
    {
        // Delete all values from the PlayerPrefs file.
        PlayerPrefs.DeleteAll();
    }
}