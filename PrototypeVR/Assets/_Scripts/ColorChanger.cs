using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material selectMaterial = null;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        interactable = GetComponent<XRBaseInteractable>();
    }
    public void SetSelectMaterial()
    {
        print("Button Pressed!");
        meshRenderer.material = selectMaterial;
    }

    public void SetOriginalMaterial()
    {
        meshRenderer.material = originalMaterial;
    }
}
