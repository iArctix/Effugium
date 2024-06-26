using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject[] roomPrefabs; // Array of room prefabs
    private GameObject currentRoomInstance;

    void Start()
    {
        LoadRoom(playerStats.currentRoom);
    }

    public void LoadRoom(int roomIndex)
    {
        if (currentRoomInstance != null)
        {
            Destroy(currentRoomInstance);
        }

        if (roomIndex < roomPrefabs.Length)
        {
            currentRoomInstance = Instantiate(roomPrefabs[roomIndex], Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("No more rooms to load.");
        }
    }

    public void CompleteRoom()
    {
        playerStats.currentRoom++;
        if (playerStats.currentRoom < playerStats.totalRooms)
        {
            LoadRoom(playerStats.currentRoom);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}