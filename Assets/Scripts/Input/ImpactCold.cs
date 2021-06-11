using UnityEngine;
using System.Collections;

public class ImpactCold : MonoBehaviour
{
    private int limite;
    private SpriteRenderer spriteR;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject particula;
    // Use this for initialization
    void Start()
    {
        limite = 0;
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = sprites[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 4 && collision.relativeVelocity.magnitude < 10) {
            
            if (limite < sprites.Length - 1)
            {
                limite++;
                spriteR.sprite = sprites[limite];
            }
            else
            {
                Instantiate(particula, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Destroy(gameObject);
            }

        } else if (collision.relativeVelocity.magnitude > 12 && collision.gameObject.CompareTag("Player")) {
            Instantiate(particula, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
