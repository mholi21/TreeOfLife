using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class TreeScript : MonoBehaviour {

    public GameObject dialogText;
    public GameObject elixir;

    public void CheckENMS()
    {
        GameObject[] enms = GameObject.FindGameObjectsWithTag("Enemy");
        int numberOfENMS = enms.Length;
        if(numberOfENMS == 0)
        {
            dialogText.SetActive(true);
            dialogText.GetComponent<Text>().text = "Tree of life dropped something." + Environment.NewLine + "I have to check what it is.";
            elixir.SetActive(true);
            StartCoroutine(ExecuteAfterTime(2f));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        dialogText.SetActive(false);
    }
}
