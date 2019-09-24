using UnityEngine;

public class LayerController : MonoBehaviour {

    private SpriteRenderer player1renderer;
    private SpriteRenderer player2renderer;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

	void Start () {
        player1renderer = player1.GetComponent<SpriteRenderer>();
        player2renderer = player2.GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        double pos1 = player1.transform.position.y;
        double pos2 = player2.transform.position.y;

        if(pos1 > pos2)
        {
            player1renderer.sortingOrder = 3;
            player2renderer.sortingOrder = 4;
        }
        else if(pos1 < pos2)
        {
            player1renderer.sortingOrder = 4;
            player2renderer.sortingOrder = 3;
        }
	}
}
