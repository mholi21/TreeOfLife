using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {


    public GameObject dialogText;
    public GameObject winBanner;
    public GameObject poof;
    public GameObject gnome;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            dialogText.SetActive(true);
            other.GetComponent<LoseHP>().enabled = false;
            dialogText.GetComponent<Text>().text = "Elixir of life!" + Environment.NewLine + "I'm imortal now!";
            winBanner.SetActive(true);
            StartCoroutine(ExecuteAfterTime(1f));
            StartCoroutine(ExecuteAfterTime2(4f));  
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        poof.SetActive(true);
    }

    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);

        gnome.SetActive(true);
        poof.SetActive(false);
        Destroy(gameObject);
    }
}
