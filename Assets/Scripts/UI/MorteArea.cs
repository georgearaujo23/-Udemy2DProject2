using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteArea : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PassaroUI"))
        {
            Destroy(collision.gameObject);
        }
    }
}
