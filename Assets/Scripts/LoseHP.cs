using UnityEngine;
using System.Collections;

public class LoseHP : MonoBehaviour {

    Animator _pAnim;

    void Start()
    {
        _pAnim = GetComponent<Animator>();
    }

    void Update ()
    {
        if (gameObject.GetComponent<PlayerHealthAndMana>().playerCurrentHealth > 0)
        {
            gameObject.GetComponent<PlayerHealthAndMana>().UpdateHealth(-0.2f);
        }

        if (gameObject.GetComponent<PlayerHealthAndMana>().playerCurrentHealth == 0)
        {
            _pAnim.SetBool("IsDead", true);
        }
    }
}
