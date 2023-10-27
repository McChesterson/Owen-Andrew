using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;

    public SpriteRenderer sR;
    public Color32 flashColor;
    public Color32 baseColor;
    public float flashLength;

    void Start()
    {
        sR.color = baseColor;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            health--;
            StartCoroutine("ColorFlash");
        }
    }
    IEnumerator ColorFlash()
    {
        sR.color = flashColor;
        yield return new WaitForSeconds(flashLength);
        sR.color = baseColor;
    }
}
