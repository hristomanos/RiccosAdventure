using UnityEngine;

public class Carrot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(UnityTags.Player) is false) 
            return;

        ScoreManager.Instance.AddScore();

        Destroy(gameObject);
    }
}
