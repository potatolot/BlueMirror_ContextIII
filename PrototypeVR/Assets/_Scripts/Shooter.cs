using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooter : MonoBehaviour
{
    private XRGrabInteractable interactable;

    public Transform barrel;
    public GameObject projectileUnit;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();

    }

    private void OnEnable()
    {
        interactable.onActivate.AddListener(Fire);
    }

    private void OnDisable()
    {
        interactable.onActivate.RemoveListener(Fire);
    }

    private void Fire(XRBaseInteractor interactor)
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        GameObject projectileObject = Instantiate(projectileUnit, barrel.position, barrel.rotation);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch();
    }

}
