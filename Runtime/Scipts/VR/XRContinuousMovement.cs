using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XRContinuousMovement : MonoBehaviour
{

    public XRNode inputSource;
    public LayerMask groundLayer;

    private Vector2 inputAxis;
    private CharacterController charachter;
    private XROrigin rig;
    [SerializeField]
    private float speed = 1f;
    private float fallingspeed;
    private float gravity = -9.8f;


    void Start()
    {
        rig = GetComponent<XROrigin>();
        charachter = GetComponent<CharacterController>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }
    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0.0f, rig.Camera.gameObject.transform.eulerAngles.y, 0.0f);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        charachter.Move(direction * speed * Time.deltaTime);


        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            fallingspeed = 0;
        }
        else
        {
            fallingspeed += gravity * Time.deltaTime;
        }

        charachter.Move(Vector3.up * fallingspeed * Time.deltaTime);
    }


    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(charachter.center);
        float rayLength = charachter.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, charachter.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }

    void CapsuleFollowHeadset()
    {
        charachter.height = rig.CameraInOriginSpaceHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.gameObject.transform.position);
        charachter.center = new Vector3(capsuleCenter.x, charachter.height / 2 + charachter.skinWidth, capsuleCenter.z);
    }
}
