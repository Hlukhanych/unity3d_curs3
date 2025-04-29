using UnityEngine;

public class CoinTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalData.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
