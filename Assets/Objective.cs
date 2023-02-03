using Assets.Script;
using UnityEngine;

namespace Assets
{
    public class Objective : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                GameVictoryManager.instance.OnPlayerVictory();
            }
        }
    }
}