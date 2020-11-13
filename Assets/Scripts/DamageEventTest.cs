using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageEventTest : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 damageloc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void DmgTest()
    {
        damageloc = GameManger.gamemanager.Player.transform.position;
        Debug.Log("Damaged!");
        rb.AddForce( damageloc.normalized * 1200);

    }
    public void DeathTest()
    {
        Debug.Log("Killed!");
        rb.AddForce(damageloc.normalized * 900);
        rb.freezeRotation = false;
        StartCoroutine("Death");
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(2);
        GameObject.Destroy(gameObject);
    }
}
