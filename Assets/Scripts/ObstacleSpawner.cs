using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject obstacle;
    private int xPos;
    private int zPos;
    private int enemyCount;
    public int enemyCountMax = 10;

    private void Start() {
        StartCoroutine(SpawnObstacle());
        // CarController2 carController2 = GetComponent<CarController2>();
        CarController2.OnPlayerScored += CarController_OnPlayerScored;
    }

    // IEnumerator SpawnObstacle() {
    //     while (enemyCount < enemyCountMax) {
    //         xPos = Random.Range(-26, 26);
    //         zPos = Random.Range(-26, 26);
    //         Instantiate(obstacle, new Vector3(xPos, 0, zPos), Quaternion.identity);
    //         enemyCount++;
    //         yield return new WaitForSeconds(2f);
    //     }
    // }

    private void CarController_OnPlayerScored(object sender, System.EventArgs e) {
        enemyCount--;
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            if (GameObject.FindGameObjectsWithTag("Person").Length < enemyCountMax) {
                xPos = Random.Range(-26, 26);
                zPos = Random.Range(-26, 26);
                Instantiate(obstacle, new Vector3(xPos, 0, zPos), Quaternion.identity);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
