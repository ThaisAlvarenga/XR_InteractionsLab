using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandVisualController : MonoBehaviour
{
    public GameObject handVisual;
    public XRBaseControllerInteractor interactor;

    private void Awake()
    {
        interactor = GetComponent<XRBaseControllerInteractor>();
    }

    private void OnEnable()
    {
        interactor.selectEntered.AddListener(hideHand);
        interactor.selectExited.AddListener(showHand);
    }

    private void OnDisable()
    {
        interactor.selectEntered.RemoveListener(hideHand);
        interactor.selectExited.RemoveListener(showHand);

    }

    void hideHand(SelectEnterEventArgs args)
    {
        handVisual.SetActive(false);
    }

    void showHand(SelectExitEventArgs args)
    {
        handVisual.SetActive(true);
    }

}
