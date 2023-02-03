
using UnityEngine;

namespace Assets.Script
{
    public class DeathZone : MonoBehaviour
    {

        public Transform playerSpawn;


    private void Awake() {
            playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
    } 


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.transform.position = playerSpawn.position;
            PlayerHealth.instance.TakeDamage(40);
        }
    }

    }
}




