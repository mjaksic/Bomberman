using System.Collections;
using UnityEngine;

public class portalManager : MonoBehaviour {

    [SerializeField]
    private float waitTime;

    private bool isUsed = false;
    public portalManager2 portalScript;

    public GameObject endPoint;
    private void OnTriggerStay2D(Collider2D player)
    {
        if (isUsed == false)
        {
            player.transform.position = endPoint.transform.position;

            isActivated();
            portalScript.isActivated();

            StartCoroutine(Loop(waitTime));
        }
    }

    public IEnumerator Loop(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isActivated();
        portalScript.isActivated();
    }

    public void isActivated()
    {
        isUsed = !isUsed;
    }
}
