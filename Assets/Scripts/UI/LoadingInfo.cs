using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingInfo : MonoBehaviour
{
    public Text txtCarregando;
    // Start is called before the first frame update
    public void BtnClique()
    {
        StartCoroutine(LoadGameProg());
    }

    IEnumerator LoadGameProg()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(2);
        while (!async.isDone)
        {
            txtCarregando.enabled = true;
            yield return null;

        }
    }

}
