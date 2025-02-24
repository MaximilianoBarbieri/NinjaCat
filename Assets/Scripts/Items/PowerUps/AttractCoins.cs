using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractCoins : Buff
{
    private float Duration = 5f;
    private const float AttractionSpeed = 10f;

    public override void ProcessEffect()
    {
        StartCoroutine(AttractInRange());
    }

    IEnumerator AttractInRange()
    {
        Debug.Log("Atraer monedas en rango");
        float elapsedTime = 0f;

        while (elapsedTime < Duration)
        {
            Coin[] coins = FindObjectsOfType<Coin>();

            foreach (Coin coin in coins)
            {
                if (coins != null)
                {
                    Vector3 dir = (_cat.transform.position - coin.transform.position).normalized;
                    coin.transform.position += dir * AttractionSpeed * Time.deltaTime;
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Finalizo la atraccion de monedas en rango");
    }
}