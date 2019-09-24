using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {

    public GameObject powerUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(powerUp);
    }
}
