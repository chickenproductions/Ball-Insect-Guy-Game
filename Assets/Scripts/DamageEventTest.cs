using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageEventTest : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void DmgTest()
    {
        Debug.Log("Damaged!");
        rb.AddForce( new Vector2(-rb.velocity.x * 600, 300));
    }
    public void DeathTest()
    {
        Debug.Log("Killed!");
        rb.AddForce(new Vector2(-rb.velocity.x * 800, 700));
        rb.freezeRotation = false;
        StartCoroutine("Death");
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        GameObject.Destroy(gameObject);
    }
}
