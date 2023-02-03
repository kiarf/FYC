using Assets.Script;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool _playerCollides;

    private PlayerMovement _playerMovement;

    public BoxCollider2D topCollider;

    private void Awake()
    {
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerCollides = true;
        }
    }

    private void Update()
    {
        if (_playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            _playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
        }
        else if (_playerCollides && Input.GetKeyDown(KeyCode.E))
        {
            _playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerCollides = false;
            topCollider.isTrigger = false;
            _playerMovement.isClimbing = false;
        }
    }
}