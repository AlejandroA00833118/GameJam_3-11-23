using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedGoal;
    public GameObject goal;

    void Update() {
        if (waitTime <= 0 && spawnedGoal == false) {
            for (int i = 0; i < rooms.Count; i++) {
                if (i == rooms.Count-1) {
                    Instantiate(goal, rooms[i].transform.position, Quaternion.identity);
                    spawnedGoal = true;
                }
            }
        }
        else {
            waitTime -= Time.deltaTime;
        }
    }
}
