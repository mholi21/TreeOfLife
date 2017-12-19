using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject dialogText;
    public float lifetime;

    void Start()
    {
        Invoke("DisplayDialog", 1f);
    }

    void DisplayDialog()
    {
        dialogText.SetActive(true);
        dialogText.GetComponent<Text>().text = "What was that noise!?" + Environment.NewLine + "I have to check.";
        StartCoroutine(ExecuteAfterTime(lifetime));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        dialogText.SetActive(false);
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeInHierarchy);
        }
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
