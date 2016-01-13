using UnityEngine;
using System.Collections;
using System.Linq.Expressions;

public class PlayerController : MonoBehaviour
{
    public int Speed;
    public Boundary Boundary;
    public float Tilt;

    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate;
    private float NextFire;

    void Update()
    {
        // ReSharper disable once InvertIf
        if (Input.GetButton("Fire1") && Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        var player = GetComponent<Rigidbody>();
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var velocity = new Vector3(moveHorizontal, 0.0f, moveVertical);

        player.velocity = velocity * Speed;
        player.position = new Vector3(
            Mathf.Clamp(player.position.x, Boundary.XMin, Boundary.XMax),
            0.0f,
            Mathf.Clamp(player.position.z, Boundary.ZMin, Boundary.ZMax)
        );
        player.rotation = Quaternion.Euler(
            0.0f,
            0.0f,
            player.velocity.x * -Tilt
        );
    }

}

[System.Serializable]
public class Boundary
{
    public float XMin, XMax, ZMin, ZMax;
}
