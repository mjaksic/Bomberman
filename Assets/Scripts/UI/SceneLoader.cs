using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private bool loadScene = false;

    [SerializeField]
    private int scene;
    [SerializeField]
    private TextMeshProUGUI loadingText;

    void Update()
    {

        if (loadScene == false)
        {
            loadScene = true;
            loadingText.text = "Loading...";
            StartCoroutine(LoadNewScene());

        }

        if (loadScene == true)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
        }

    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        while (!async.isDone)
        {
            yield return null;
        }

    }

    public void SceneGetter(int scene)
    {
        this.scene = scene;
    }

}