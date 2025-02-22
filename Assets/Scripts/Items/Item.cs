using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected Cat _cat => FindObjectOfType<Cat>();
    protected ItemManager ItemManager => FindObjectOfType<ItemManager>();

    private Sprite _spriteItem;
    private Color _colorItem;
    private ParticleSystem _fx;

    public Sprite SpriteItem => _spriteItem;
    public Color ColorItem => _colorItem;
    public ParticleSystem Fx => _fx;

    public abstract void ApplyFX();
    public abstract void ProcessEffect();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ProcessEffect();
            Debug.Log("Cat acaba de tocar un Item!");
        }
    }
}