using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSizeBoxCollider : MonoBehaviour
{
    private Image _imageComponent;
    private BoxCollider2D _colliderComponent;
    private void Start()
    {
        _imageComponent = GetComponent<Image>();
        _colliderComponent = GetComponent<BoxCollider2D>();

        _colliderComponent.size = new Vector2(
            _imageComponent.rectTransform.rect.width,
            _imageComponent.rectTransform.rect.height);

    }
}
