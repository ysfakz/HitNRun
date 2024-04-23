using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField] private Rigidbody rb;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (rb != null) {
                StartCoroutine(DeactivateAfterDelay(.5f, gameObject));
            }
        }
    }

    IEnumerator DeactivateAfterDelay(float delay, GameObject gameObject)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}
