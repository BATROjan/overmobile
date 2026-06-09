using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractebleObjectScript : MonoBehaviour
{
    public Transform PointTransform => pointTransform;
    public Transform TransitPointTransform => transitPointTransform;

    [SerializeField] private Transform pointTransform;
    [SerializeField] private Transform transitPointTransform;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public abstract void Iteractive();
    public abstract void SelectObject();
    public abstract void DeleteObject();
    public abstract void DeathAnimation();
    public abstract void Attack();
    public abstract InteractiveObjectType ReturnType();
    public abstract int ReturnLvL();
    public abstract GameObject ReturnLvLtext();
}
public enum InteractiveObjectType
{
    None,
    Chest,
    Enemy
}
