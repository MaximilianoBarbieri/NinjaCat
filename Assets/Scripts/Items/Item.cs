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

    private MeshRenderer _view => GetComponent<MeshRenderer>();
    private SphereCollider _collider => GetComponent<SphereCollider>();

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
            DesactiveViewItem(false);

            Debug.Log("Cat acaba de tocar un Item!");
        }
    }

    private void DesactiveViewItem(bool value)
    {
        _collider.enabled = value;
        _view.enabled = value;
    }
}