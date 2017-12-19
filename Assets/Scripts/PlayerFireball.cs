using UnityEngine;
using System.Collections;

public class PlayerFireball : MonoBehaviour {

    public float speed;
    public float lifetime;
    Animator _pAnim;

    void Start ()
    {
        _pAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        
        if (_pAnim.GetFloat("Input_y") == 1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
        }
        if (_pAnim.GetFloat("Input_y") == -1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed);
        }
        if (_pAnim.GetFloat("Input_x") == 1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        }
        if (_pAnim.GetFloat("Input_x") == -1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        }
    }
	
	void Update ()
    {
        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            Destroy(gameObject);
        }

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name != "Player")
        {
            other.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().ChangeScore(1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthAndMana>().UpdateHealth(50f);
            GameObject.FindGameObjectWithTag("Tree").GetComponent<TreeScript>().CheckENMS();
            Destroy(gameObject);
        }
    }
}
