using UnityEngine;

[RequireComponent(typeof(AudioClip))]

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float countdown;

    public AudioClip explosionSound;
    public Collider2D bombCollider;

    private float timer;

    private void Start()
    {
        bombCollider = GetComponent<Collider2D>();
        timer = 0f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, timer / countdown);

        if (timer >= countdown)
        {
            FindObjectOfType<MapDestroyer>().Explode(transform.position);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bombCollider.isTrigger = false;
        }
    }
}
