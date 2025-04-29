using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public float limitSeconds = 60f;
    private bool timeOutTriggered = false;

    private void Update()
    {
        if (!timeOutTriggered && Time.time - GlobalData.Instance.Data.startTime > limitSeconds)
        {
            timeOutTriggered = true;

            if (!GlobalData.Instance.IsGameOver())
            {
                Debug.Log("Час вийшов!");
                GlobalData.Instance.TriggerLose();
            }
        }
    }
}
