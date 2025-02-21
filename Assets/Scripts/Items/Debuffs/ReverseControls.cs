using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseControls : Debuff
{
    public float duration = 5f; // Duración del debuff en segundos

    public override void ProcessEffect()
    {
        StartCoroutine(ApplyReverseControls());
    }

    private IEnumerator ApplyReverseControls()
    {
        // Activar el cambio global en los controles
        ItemManager.Instance.isControlsReversed = true;

        // Esperar la duración del debuff
        yield return new WaitForSeconds(duration);

        // Restaurar controles normales
        ItemManager.Instance.isControlsReversed = false;
    }
}