using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class OutlinableCube : MonoBehaviour
{
    [SerializeField] private MeshRenderer outlineRenderer;
    private bool isSelected;
    private Rotate rotateComponent;
    private MaterialPropertyBlock materialPropertyBlock;

    private void Awake()
    {
        rotateComponent = GetComponent<Rotate>();
        materialPropertyBlock = new MaterialPropertyBlock();
        outlineRenderer.GetPropertyBlock(materialPropertyBlock);
    }

    void OnMouseDown()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        isSelected = !isSelected;
        rotateComponent.SetStatus(isSelected);
        UpdateOutline(isSelected);
    }

    private void UpdateOutline(bool isActive)
    {
        if (isActive)
        {
            Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            materialPropertyBlock.SetColor("_OutlineColor", newColor);
        }
        
        materialPropertyBlock.SetFloat("_IsActive", isActive ? 1.0f : 0f);
        outlineRenderer.SetPropertyBlock(materialPropertyBlock);
    }
}
