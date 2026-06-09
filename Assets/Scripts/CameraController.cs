using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;

    public void ShakeCamera()
    {
        transform.DOShakePosition(0.3f, 0.5f, 1);
    }

    public void MakeNewSize(float value)
    {
        camera.DOOrthoSize(value, 1);
    }
}
