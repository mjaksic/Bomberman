using UnityEngine;

public class Player1 : Character
{
    private int tmpHealthHolder;

    protected override void Start()
    {
        base.Start();
        tmpHealthHolder = playerHealth;
        FindObjectOfType<GameManager>().GetP1Health(tmpHealthHolder);
    }

    protected override void Update()
    {
        GetInput();
        base.Update();
        if(tmpHealthHolder != playerHealth)
        {
            tmpHealthHolder = playerHealth;
            FindObjectOfType<GameManager>().GetP1Health(tmpHealthHolder);
        }
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2Int.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

    }

}
