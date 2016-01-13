using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public float Tumble;

    void Start()
    {
        var component = GetComponent<Rigidbody>();
        component.angularVelocity = Random.insideUnitSphere * Tumble;
    }
}
