using UnityEngine;
using System.Collections;

public class PotionPickup : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthAndMana>().UpdateHealth(100f);
            Destroy(gameObject);
        }
    }

}
