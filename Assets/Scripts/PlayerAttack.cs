using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

    public GameObject PlayerFireball;
    public GameObject FireballPosition;
    int i = 0;
    Animator _pAnim;

    void Start()
    {
        _pAnim = GetComponent<Animator>();
    }

    void Update ()
    {
        if (Input.GetKeyDown("space") && (gameObject.GetComponent<PlayerHealthAndMana>().playerCurrentMana > 10f) && !_pAnim.GetBool("IsDead"))
        {
            _pAnim.SetBool("IsCasting", true);
            GameObject fireball = (GameObject)Instantiate(PlayerFireball);
            gameObject.GetComponent<PlayerHealthAndMana>().UpdateMana(-10f);
            fireball.transform.position = FireballPosition.transform.position;
            StartCoroutine(ExecuteAfterTime(0.1f));
        }
	}

    public void ChangeScore(int a)
    {
        i += a;
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "Enemies:" + i + "/10";
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        _pAnim.SetBool("IsCasting", false);
    }
}
