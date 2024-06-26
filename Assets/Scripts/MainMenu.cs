using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerStats playerStats;

    public void SetTotalRooms(int rooms)
    {
        playerStats.totalRooms = rooms;
        playerStats.currentRoom = 0; // Reset current room to 0
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}