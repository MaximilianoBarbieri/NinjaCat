using System.Collections;
using UnityEngine;

public class AttractCoins : Buff
{
    private const float AttractionSpeed = 10f;

    protected override void ProcessEffect()
    {
        StartCoroutine(AttractInRange());
    }

    IEnumerator AttractInRange()
    {
        Debug.Log("Atraer monedas en rango");
        float elapsedTime = 0f;

        while (elapsedTime < DurationEffect)
        {
            Coin[] coins = FindObjectsOfType<Coin>();

            foreach (Coin coin in coins)
            {
                if (coins != null)
                {
                    Vector3 dir = (Cat.transform.position - coin.transform.position).normalized;
                    coin.transform.position += dir * AttractionSpeed * Time.deltaTime;
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Finalizo la atraccion de monedas en rango");
    }
}