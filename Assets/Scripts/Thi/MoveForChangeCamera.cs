using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class MoveForChangeCamera : MonoBehaviour
{
    public Transform pointX;
    public GameObject cube;
    public GameObject camera1;
    public GameObject camera2;
    public float speed = 3f;
    public GameObject player;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointX.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, pointX.position) < 0.1f)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            StartCoroutine(MoveCamera());
        }
    }

    IEnumerator MoveCamera()
    {
        yield return new WaitForSeconds(2f);
        camera1.SetActive(true);
        camera2.SetActive(false);
    }
}