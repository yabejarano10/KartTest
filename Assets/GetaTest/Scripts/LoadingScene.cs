using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private Image progressbar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOp());
    }

    IEnumerator LoadAsyncOp()
    {
        AsyncOperation game = SceneManager.LoadSceneAsync("TrackScene");
        while(game.progress < 1)
        {
            progressbar.fillAmount = game.progress;
            yield return new WaitForEndOfFrame();
        }

    }
}
