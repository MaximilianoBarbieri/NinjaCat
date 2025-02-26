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
        // Activar el cambio global en los controles
        ItemManager.OnModifyControls?.Invoke(true);

        // Esperar la duración del debuff
        yield return new WaitForSeconds(DurationEffect);

        // Restaurar controles normales
        ItemManager.OnModifyControls?.Invoke(false);
    }
}