using Cinemachine;
using UnityEngine;

public class VirtualCameraBehaviour : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        cinemachineVirtualCamera.m_Follow = GameManager.GetPlayer().transform;
    }
}
