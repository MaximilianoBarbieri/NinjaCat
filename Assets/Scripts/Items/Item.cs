using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected Cat Cat => FindObjectOfType<Cat>();
    private MeshRenderer _view => GetComponent<MeshRenderer>();
    private SphereCollider _collider => GetComponent<SphereCollider>();
    protected ItemManager ItemManager => FindObjectOfType<ItemManager>();

    [SerializeField] private Sprite _spriteItem;
    [SerializeField] private Color _colorItem;

    protected ParticleSystem _fx;

    protected const float DurationEffect = 3f;

    public abstract void ApplyFX();
    protected abstract void ProcessEffect();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ProcessEffect();

            DesactiveViewItem(false);

            Debug.Log("Cat acaba de tocar un Item!");

            if (gameObject.CompareTag("Coin")) return;

            UIManager.OnRefreshCurrentItem?.Invoke(_spriteItem, _colorItem, DurationEffect);
        }
    }

    private void DesactiveViewItem(bool value)
    {
        _collider.enabled = value;
        _view.enabled = value;
    }
}