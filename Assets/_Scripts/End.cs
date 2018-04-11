using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        //float fadeTime = GetComponent<Fading>().BeginFade(1);
        //yield return new WaitForSeconds(fadeTime);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("end");
    }
}
