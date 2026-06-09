using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goblin : InteractebleObjectScript
{
    [SerializeField] private int lvlUpCount;
    [SerializeField] private InteractiveObjectType Type;
    [SerializeField] private Text lvlText;
    [SerializeField] private GameObject lvlPanel;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Animator anim;

    public override void Attack()
    {
        var effect = Instantiate(hitEffect, new Vector3(transform.position.x, transform.position.y +0.5f, transform.position.z), Quaternion.Euler(0,80,-90));
        effect.transform.DOMove(new Vector3(player.transform.position.x, player.transform.position.y + 1.29f, player.transform.position.z), 0.15f);
    }

    public override void DeathAnimation()
    {
        anim.SetBool("Death", true);
    }

    public override void DeleteObject()
    {
        Destroy(gameObject);
    }

    public override void Iteractive()
    {
    }

    public override int ReturnLvL()
    {
        return lvlUpCount;

    }

    public override GameObject ReturnLvLtext()
    {
        return lvlPanel;
    }

    public override InteractiveObjectType ReturnType()
    {
        return Type;
    }

    public override void SelectObject()
    {
        transform.DOShakeScale(0.3f, 1, 2);
    }
}
