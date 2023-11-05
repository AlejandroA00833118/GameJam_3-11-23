using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] tile1topRooms;
    public GameObject[] tile2topRooms;
    public GameObject[] tile3topRooms;
    public GameObject[] tile4topRooms;
    public GameObject[] tile5topRooms;
    public GameObject[] tile6topRooms;

    public GameObject[] tile1rightRooms;
    public GameObject[] tile2rightRooms;
    public GameObject[] tile3rightRooms;
    public GameObject[] tile4rightRooms;
    public GameObject[] tile5rightRooms;
    public GameObject[] tile6rightRooms;

    public GameObject[] tile1bottomRooms;
    public GameObject[] tile2bottomRooms;
    public GameObject[] tile3bottomRooms;
    public GameObject[] tile4bottomRooms;
    public GameObject[] tile5bottomRooms;
    public GameObject[] tile6bottomRooms;

    public GameObject[] tile1leftRooms;
    public GameObject[] tile2leftRooms;
    public GameObject[] tile3leftRooms;
    public GameObject[] tile4leftRooms;
    public GameObject[] tile5leftRooms;
    public GameObject[] tile6leftRooms;

    public GameObject[][][] tilesRooms = new GameObject[4][][];

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedGoal;
    public GameObject goal;

    void Start() {
        tilesRooms[2] = new GameObject[][] {tile1topRooms, tile2topRooms, tile3topRooms, tile4topRooms, tile5topRooms, tile6topRooms};
        tilesRooms[3] = new GameObject[][] {tile1rightRooms, tile2rightRooms, tile3rightRooms, tile4rightRooms, tile5rightRooms, tile6rightRooms};
        tilesRooms[0] = new GameObject[][] {tile1bottomRooms, tile2bottomRooms, tile3bottomRooms, tile4bottomRooms, tile5bottomRooms, tile6bottomRooms};
        tilesRooms[1] = new GameObject[][] {tile1leftRooms, tile2leftRooms, tile3leftRooms, tile4leftRooms, tile5leftRooms, tile6leftRooms};
    }

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