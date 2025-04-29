using UnityEngine;

public class FinishTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Фініш!");
        }
    }
}
