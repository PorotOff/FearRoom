using UnityEngine;

public class DisappearAsPlayerApproach : MonoBehaviour
{
    private NormalizeDistanceBetween normalizeDistanceBetween;

    private Renderer currentObjectRenderer;

    private MaterialPropertyBlock materialPropertyBlock;

    private void Awake()
    {
        normalizeDistanceBetween = GetComponent<NormalizeDistanceBetween>();

        currentObjectRenderer = GetComponent<Renderer>();

        materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void Update()
    {
        Disappear();
    }

    // private void Disappear()
    // {
    //     Color currentObjectColor = currentObjectRenderer.material.color;
    //     currentObjectColor.a = normalizeDistanceBetween.GetNormalisedDistance();
        
    //     Debug.Log($"Current mat color: {currentObjectColor}");        
    //     Debug.Log($"Norm dist: {normalizeDistanceBetween.GetNormalisedDistance()}");
    // }

    private void Disappear()
    {
        // Получаем текущий цвет материала через MaterialPropertyBlock
        currentObjectRenderer.GetPropertyBlock(materialPropertyBlock);

        // Получаем текущий цвет
        Color currentObjectColor = materialPropertyBlock.GetColor("_BaseColor");

        // Изменяем альфа-канал
        currentObjectColor.a = normalizeDistanceBetween.GetNormalisedDistance();

        // Устанавливаем обновленный цвет обратно в MaterialPropertyBlock
        materialPropertyBlock.SetColor("_BaseColor", currentObjectColor);

        // Применяем обновленные свойства материала к рендереру
        currentObjectRenderer.SetPropertyBlock(materialPropertyBlock);

        // Для отладки
        Debug.Log($"Norm dist: {normalizeDistanceBetween.GetNormalisedDistance()}");
    }
}