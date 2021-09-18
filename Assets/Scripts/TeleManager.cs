using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider TpProv;
    private InputAction _thumbstick;
    private bool is_Active;
    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;
        
        _thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        _thumbstick.Enable();

    }
    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        is_Active = true;
        
    }
    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        is_Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_Active)
            return;
        
        if(_thumbstick.triggered)
            return;
        
        if(!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            is_Active = false;
        }
        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };

        TpProv.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        is_Active = false;
    }
}
