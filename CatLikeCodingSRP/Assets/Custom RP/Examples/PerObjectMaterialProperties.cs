﻿using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{
    static MaterialPropertyBlock block;
    static int
        baseColorId = Shader.PropertyToID("_BaseColor"),
        cutoffId = Shader.PropertyToID("_Cutoff"),
        metallicId = Shader.PropertyToID("_Metallic"),
        smoothnessId = Shader.PropertyToID("_Smoothness");

    [SerializeField]
    Color baseColor = Color.white;
    [SerializeField, Range(0f, 1f)]
    float cutoff = 0.5f, metallic = 0f, smoothness = 0.5f;

    void Awake()
    {
        OnValidate();
    }
    void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        baseColor = Random.ColorHSV(0,1,0.6f, 1, 0.8f,1);
        cutoff = Random.Range(0.3f, 0.8f);
        block.SetColor(baseColorId, baseColor);
        block.SetFloat(cutoffId, cutoff);
        block.SetFloat(metallicId, metallic);
        block.SetFloat(smoothnessId, smoothness);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
}