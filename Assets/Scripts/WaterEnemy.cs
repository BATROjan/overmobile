using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WaterEnemy : InteractebleObjectScript
{
    [SerializeField] private int lvlUpCount;
    [SerializeField] private InteractiveObjectType Type;
    [SerializeField] private Text lvlText;
    [SerializeField] private Image lvlImage;
    [SerializeField] private GameObject lvlPanel;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject hitEffect;

    public override void Attack()
    {
        var effect = Instantiate(hitEffect, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.Euler(0, 80, -90));
        effect.transform.DOMove(new Vector3(player.transform.position.x, player.transform.position.y + 1.29f, player.transform.position.z), 0.15f);
    }

    public override void DeathAnimation()
    {
    }

    public override void DeleteObject()
    {
    }

    public override void Iteractive()
    {
    }
    public override int ReturnLvL()
    {
        return lvlUpCount;

    }

    public void ActivePanel()
    {
        lvlImage.DOFade(1, 2);
        lvlText.DOFade(1, 2);
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
    }
}
