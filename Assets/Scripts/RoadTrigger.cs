using UnityEngine;
using static Utils;

public class RoadTrigger : MonoBehaviour
{
    public enum TriggerType
    {
        ActivateRoad,
        DeactivateRoad
    }

    public TriggerType triggerType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TAG_PLAYER))
        {
            RoadManager roadManager = FindObjectOfType<RoadManager>();
            if (roadManager == null) return;

            if (triggerType == TriggerType.ActivateRoad)
            {
                roadManager.ActivateNewRoad(); 
            }
            else if (triggerType == TriggerType.DeactivateRoad)
            {
                roadManager.DeactivateOldestRoad(); 
            }
        }
    }
}