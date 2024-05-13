using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField] GameManager gameManager;
    public GameObject obstacle;
    private int xPos;
    private int zPos;
    private int enemyCount;
    public int enemyCountMax = 10;
    public Transform spawnArea;
    private bool isActive = false;
    private Coroutine spawnRoutine;

    private void Start() {
        // CarController2 carController2 = GetComponent<CarController2>();
        CarController2.OnPlayerScored += CarController_OnPlayerScored;
    }

    private void Update() {
        if (gameManager.IsGamePlaying() && !isActive) {
            spawnRoutine = StartCoroutine(SpawnObstacle());
            isActive = true;
        }
        if (gameManager.IsGameOver() && isActive) {
            StopCoroutine(spawnRoutine);
            isActive = false;
        }
    }

    private void CarController_OnPlayerScored(object sender, System.EventArgs e) {
        enemyCount--;
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            if (GameObject.FindGameObjectsWithTag("Person").Length < enemyCountMax) {
                xPos = Random.Range(-26, 26);
                zPos = Random.Range(-26, 26);
                Instantiate(obstacle, new Vector3(xPos, 0, zPos), Quaternion.identity, spawnArea);
                // enemyCount++;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
