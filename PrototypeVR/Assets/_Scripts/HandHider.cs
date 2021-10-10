using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    private GameObject handtransform;
    private XRDirectInteractor interactor = null;

    private void Start()
    {
        handtransform = transform.GetChild(0).gameObject;
        interactor = GetComponent<XRDirectInteractor>();
    }

    
    public void Show()
    {
        handtransform.SetActive(true);
    }

    public void Hide()
    {
        handtransform.SetActive(false);
    }
}