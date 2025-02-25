using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    public float radius = 5f; // Радіус астроїди
    public float speed = 1f;  // Швидкість руху
    private float t = 0f;     // Кутовий параметр

    void Update()
    {
        t += speed * Time.deltaTime; // Оновлюємо параметр t
        float x = radius * Mathf.Pow(Mathf.Cos(t), 3);
        float y = radius * Mathf.Pow(Mathf.Sin(t), 3);
        
        transform.position = new Vector3(x, y, 0);
    }
}
