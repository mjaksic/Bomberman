using UnityEngine;

public class Player2 : Character
{
    private int tmpHealthHolder;

    protected override void Start()
    {
        base.Start();
        tmpHealthHolder = playerHealth;
        FindObjectOfType<GameManager>().GetP2Health(tmpHealthHolder);
    }

    protected override void Update()
    {
        GetInput();
        base.Update();
        if(tmpHealthHolder != playerHealth)
        {
            tmpHealthHolder = playerHealth;
            FindObjectOfType<GameManager>().GetP2Health(tmpHealthHolder);
        }
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2Int.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
        }

    }

}
