using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : InteractebleObjectScript
{
    [SerializeField] private int lvlUpCount;
    [SerializeField] private InteractiveObjectType Type;
    [SerializeField] private GameObject lvlPanel;
    [SerializeField] private Material material;
    [SerializeField] private Animator anim;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private GameObject openEffect;
    [SerializeField] private AudioSource openAudio;

    private void Start()
    {
       
    }
    public override int ReturnLvL()
    {
        return lvlUpCount;
    }

    public override InteractiveObjectType ReturnType()
    {
        return Type;
    }

    public override void Iteractive()
    {
        anim.Play("Open");
        openAudio.Play();
        Instantiate(openEffect, new Vector3(-2.611f, 2.506f, 1.718f), Quaternion.Euler(0,54,0));
    }

    public override GameObject ReturnLvLtext()
    {
        return lvlPanel;
    }

    public override void SelectObject()
    {
        transform.DOShakeScale(0.3f, 5, 2);
    }

    public override void DeleteObject()
    {
        material.DOFade(0, 1).SetEase(Ease.Linear).OnComplete(() =>
        {
            Destroy(gameObject);
            material.DOFade(1, 0);
        });
    }

    public override void DeathAnimation()
    {
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
