using UnityEngine;

public class TrapTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalData.Instance.TakeDamage();
        }
    }
}
