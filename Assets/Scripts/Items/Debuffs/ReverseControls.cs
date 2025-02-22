using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseControls : Debuff
{
    private const float Duration = 5f; // Duración del debuff en segundos

    public override void ProcessEffect()
    {
        StartCoroutine(ApplyReverseControls());
    }

    private IEnumerator ApplyReverseControls()
    {
        // Activar el cambio global en los controles
        ItemManager.OnModifyControls?.Invoke(true);

        // Esperar la duración del debuff
        yield return new WaitForSeconds(Duration);

        // Restaurar controles normales
        ItemManager.OnModifyControls?.Invoke(false);
    }
}