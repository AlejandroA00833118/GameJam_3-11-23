using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private RoomTemplates templates;

    public int openSide; // 1: Top, 2: Right, 3: Bottom, 4: Left
    private int rand;
    private bool spawned = false;

    public int tileType = -1;

    public float waitTime = 4f;

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);

        if (tileType == -1) {
            tileType = Random.Range(0, 6);
        }
    }

    void Spawn() {
        if (spawned == false) {
            spawned = true;
            rand = Random.Range(0, templates.tilesRooms[openSide-1][tileType].Length);
            GameObject newRoom = Instantiate(templates.tilesRooms[openSide-1][tileType][rand], transform.position, templates.tilesRooms[openSide-1][tileType][rand].transform.rotation);
            RoomSpawner script = newRoom.GetComponentInChildren<RoomSpawner>();
            rand = Random.Range(0, 100);
            if (rand < 80) {
                script.tileType = tileType;
            }
            else {
                script.tileType = Random.Range(0,6);
            }
        }
    }

    void spawnRoom() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("SpawnPoint")) {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}