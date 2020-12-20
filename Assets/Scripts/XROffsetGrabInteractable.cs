using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initionalAttachLocalPos;
    private Quaternion initionalAttachLocalRot;

    // Start is called before the first frame update
    void Start()
    {
        //Create attach point
        if(!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initionalAttachLocalPos = attachTransform.localPosition;
        initionalAttachLocalRot = attachTransform.localRotation;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if(interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initionalAttachLocalPos;
            attachTransform.localRotation = initionalAttachLocalRot;
        }
        base.OnSelectEntered(interactor);
    }
}
