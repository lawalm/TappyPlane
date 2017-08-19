using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public GameObject columnPrefab;
    public int columnPoolSize = 5;
    public float spawnRate = 3f;
    public float columnMin = -1.3f;
    public float columnMax = -1.3f;

    private GameObject[] columns;
    private int currentColumn = 0;
    private Vector2 objectPoolPosition = new Vector2(-15, 25);
    private float spawnXPosition = 10f;

    private float timeSinceLastSpwaned;


    // Use this for initialization
    void Start () {
        timeSinceLastSpwaned = 0f;
        columns = new GameObject[columnPoolSize];

        for (int i = 0; i < columnPoolSize; i++) {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpwaned += Time.deltaTime;

        if (GameController.instance.gameOver == false && timeSinceLastSpwaned >= spawnRate) {

            timeSinceLastSpwaned = 0f;
            float spawnYposition = Random.Range(columnMin, columnMax);

            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYposition);
            currentColumn++;

            if (currentColumn >= columnPoolSize) {
                currentColumn = 0;
            }
        }
    }
}
