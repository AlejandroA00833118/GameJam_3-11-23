using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] props;

    public int propsMaxItems = 10;

    public float waitTime = 4f;

    void Start()
    {
        StartCoroutine(SpawnProps());
    }

    IEnumerator SpawnProps() {
        int randomAmount = Random.Range(5, propsMaxItems);
        for (int i = 0; i < randomAmount; i++) {
            int randomIndex = Random.Range(0, props.Length);
            float offsetX = Random.Range(-4f, 4f);
            float offsetY = Random.Range(-3.5f, 3.5f);
            Vector3 offset = new Vector3(offsetX, offsetY, 0);
            Instantiate(props[randomIndex], transform.position + offset, Quaternion.identity);
        }
        yield return null;
    }
}
