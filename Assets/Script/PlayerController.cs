using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour
{
    public float m_Gravity = 30.0f;
    public float m_Sensitivity = 0.1f;
    public float m_Maxspeed = 1.0f;
    public float m_RotateIncrement = 90;

    public SteamVR_Action_Boolean m_RotatePress = null;
    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_Speed = 0.0f;
    private bool iswalk = false;

    private CharacterController m_CharacterController = null;
    private Transform m_CameraRig = null;
    private Transform m_Head = null;

    private AudioSource walk;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        m_CameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;
        
        walk = GetComponent<AudioSource>();
        walk.Stop();
    }

    // Update is called once per frame
    private void Update()
    {
        //HandleHead();
        HandleHeight();
        CalculateMovement();
        //SnapRotation();
        
        if(iswalk && !walk.isPlaying)
            walk.Play();
    }
    /*
    private void HandleHead()
    {
        // Store current
        Vector3 oldPosition = m_CameraRig.position;
        Quaternion oldRotation = m_CameraRig.rotation;
        // Rotation
        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        // Restore
        m_CameraRig.position = oldPosition;
        m_CameraRig.rotation = oldRotation;
    }
    */
    private void HandleHeight()
    {
        // Get the head in local space
        //float headHeight = Mathf.Clamp(m_Head.transform.position.y, 1, 5);
        //m_CharacterController.height = headHeight;

        // Cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_CharacterController.height;// / 2;
        newCenter.y += m_CharacterController.skinWidth;

        // Move capsule in local space
        //newCenter.x = m_Head.position.x;
        //newCenter.z = m_Head.position.z;
        newCenter.x = m_CharacterController.center.x;
        newCenter.z = m_CharacterController.center.z;

        /* Rotate
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;
        */
        // Apply
        m_CharacterController.center = newCenter;
    }

    private void CalculateMovement()
    {
        // Figure out  movement 
        Quaternion orientation = CalculateOrientation();
        Vector3 movement = Vector3.zero;

        // If not moving
        if (m_MoveValue.axis.magnitude == 0)
        {
            m_Speed = 0;
            iswalk = false;
        }
        // Add, clamp
        m_Speed += m_MoveValue.axis.magnitude * m_Sensitivity;
        m_Speed = Mathf.Clamp(m_Speed, -m_Maxspeed, m_Maxspeed);

        // Orientation, and Gravity
        movement += orientation * (m_Speed * Vector3.forward);

        // Gravity
        movement.y -= m_Gravity * Time.deltaTime;
        // Apply 
        m_CharacterController.Move(movement * Time.deltaTime);
        if (m_Speed > 0)
        {
            iswalk = true;
        }
    }

    private Quaternion CalculateOrientation()
    {
        float rotation = Mathf.Atan2(m_MoveValue.axis.x, m_MoveValue.axis.y);
        rotation *= Mathf.Rad2Deg;

        Vector3 orientationEuler = new Vector3(0, m_Head.eulerAngles.y+rotation, 0);
        return Quaternion.Euler(orientationEuler);
    }
    /*
    private void SnapRotation()
    {
        float snapValue = 0.0f;

        if (m_RotatePress.GetStateDown(SteamVR_Input_Sources.LeftHand))
            snapValue = -Mathf.Abs(m_RotateIncrement);

        if (m_RotatePress.GetStateDown(SteamVR_Input_Sources.RightHand))
            snapValue = Mathf.Abs(m_RotateIncrement);

        transform.RotateAround(m_Head.position, Vector3.up, snapValue);
    }
    */
}

