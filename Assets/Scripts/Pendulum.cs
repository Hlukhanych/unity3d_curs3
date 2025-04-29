using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float swingAngle = 30f; // Максимальний кут відхилення
    public float speed = 2f; // Швидкість коливання

    private float startRotation;

    void Start()
    {
        startRotation = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * swingAngle;
        transform.rotation = Quaternion.Euler(0, 0, startRotation + angle);
    }
}
