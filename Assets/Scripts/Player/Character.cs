using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    public int playerHealth;
    private Rigidbody2D charRigidbody;
    protected Vector2 direction;
    protected Animator charAnimator;
    private float waitTime = 2f;
    private bool invincible = false;
    private float timer;

    public bool IsMoving{
        get{return direction.x != 0 || direction.y != 0;}
    }

    protected virtual void Start ()
    {
        charRigidbody = GetComponent<Rigidbody2D>();
        charAnimator = GetComponent<Animator>();
	}
	protected virtual void Update ()
    {
        MovementHandler();
        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(playerHealth >= 1) { Move(); }

        else if(playerHealth <= 0)
        {
            charAnimator.SetLayerWeight(2, 1);
        }
    }

    public void Move()
    {
        charRigidbody.velocity = direction.normalized * playerSpeed;
    }

    public void MovementHandler()
    {
        if (IsMoving)
        {
            charAnimator.SetLayerWeight(1, 1);
            charAnimator.SetFloat("MovingX", direction.x);
            charAnimator.SetFloat("MovingY", direction.y);
        }
        else if (!IsMoving)
        {
            charAnimator.SetLayerWeight(1, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D objToCollide)
    {
        if(objToCollide.gameObject.tag == "movementSpeed") { playerSpeed += 0.5f; }
    }

    private void OnTriggerEnter2D(Collider2D objToCollide)
    {
        if (objToCollide.gameObject.tag == "Explosion" && invincible == false)
        {
            playerHealth--;
            StartCoroutine(Invincibility(waitTime));
        }
    }

    private IEnumerator Invincibility(float waitTime)
    {
        invincible = true;
        if (playerHealth > 0) { GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.grey, timer / waitTime); }
        yield return new WaitForSeconds(waitTime);
        invincible = false;
        GetComponent<Renderer>().material.color = Color.white;
    }
}
