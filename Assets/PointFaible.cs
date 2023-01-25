using UnityEngine;

public class PointFaible : MonoBehaviour
{
    public GameObject ObjectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Joueur"))
        {
            Destroy(ObjectToDestroy);
        }
    }
}
