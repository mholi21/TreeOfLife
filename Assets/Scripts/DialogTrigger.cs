using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DialogTrigger : MonoBehaviour {

    public GameObject dialogText;
    public GameObject audioSource;
    public float lifetime;
    public string Line1;
    public string Line2;
    public AudioClip PlayerLine;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            dialogText.SetActive(true);
            dialogText.GetComponent<Text>().text = Line1 + Environment.NewLine + Line2;
            audioSource.GetComponent<AudioSource>().clip = PlayerLine;
            audioSource.GetComponent<AudioSource>().Play();
            StartCoroutine(ExecuteAfterTime(lifetime));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        dialogText.SetActive(false);
        gameObject.SetActive(false);
    }
}
