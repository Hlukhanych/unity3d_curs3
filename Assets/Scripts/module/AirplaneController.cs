using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public Transform dropPoint; // Точка скидання вантажу
    public GameObject cargoPrefab; // Префаб вантажу (звичайний куб)
    public float radius = 10f; // Радіус кола
    public float speed = 5f; // Швидкість руху
    private float angle = 0f;

    void Update()
    {
        // Рух літака по колу
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, transform.position.y, z);
        transform.LookAt(Vector3.zero); // Літак завжди дивиться в центр кола

        // Скидання вантажу
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropCargo();
        }
    }

    void DropCargo()
    {
        Instantiate(cargoPrefab, dropPoint.position, Quaternion.identity);
    }
}