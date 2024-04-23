using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour{
    public float collisionForce = 1000f; // Adjust this value as needed
    [SerializeField] private GameManager gameManager;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Person")) {
            Rigidbody personRb = collision.gameObject.GetComponent<Rigidbody>();
            if (personRb != null)
            {
                gameManager.Scored();
                Vector3 direction = collision.contacts[0].point - transform.position;
                direction = -direction.normalized;
                personRb.AddForce(direction * collisionForce, ForceMode.Impulse);
                StartCoroutine(DeactivateAfterDelay(2f, collision.gameObject));
            }
        }
    }

    IEnumerator DeactivateAfterDelay(float delay, GameObject gameObject)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
