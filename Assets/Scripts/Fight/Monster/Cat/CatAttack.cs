using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CatAttack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Main Base"))
        {
            this.GetComponent<Transform>().parent.GetComponent<Cat>().SetTarget(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Main Base"))
        {
            this.GetComponent<Transform>().parent.GetComponent<Cat>().SetTarget(null);
        }
    }
}
