using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
}
