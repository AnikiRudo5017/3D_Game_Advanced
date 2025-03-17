using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Transform pos;
    public float speed = 2f;

    void Start()
    {
        StartCoroutine(MoveAndAction());
    }

    IEnumerator MoveAndAction()
    {
        while (Vector3.Distance(transform.position, pos.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos.position, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        transform.Rotate(0, 90, 0);
        yield return new WaitForSeconds(1f);
        Debug.Log("Fire");
    }
}
