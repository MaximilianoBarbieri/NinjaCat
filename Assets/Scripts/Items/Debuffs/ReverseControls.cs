using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseControls : Debuff
{
    protected override void ProcessEffect()
    {
        StartCoroutine(ApplyReverseControls());
    }

    private IEnumerator ApplyReverseControls()
    {
        ItemManager.OnModifyControls?.Invoke(true);

        yield return new WaitForSeconds(DurationEffect);

        ItemManager.OnModifyControls?.Invoke(false);
    }
}