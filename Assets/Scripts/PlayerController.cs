using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private WaterEnemy[] waterEnemies;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject LvLUpEffect;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform textParent;
    [SerializeField] private Text lvlText;
    [SerializeField] private int currentLvl;

    [SerializeField] private AudioSource runAudio;
    [SerializeField] private AudioSource lvlUpAudio;
    [SerializeField] private AudioSource AttackAudio;
    [SerializeField] private AudioSource HurtAudio;

    private Sequence sequence;
    private InteractebleObjectScript objectHit;
    private bool canMove = true;
    private bool canAttackWaterEnemy = false;
    void Start()
    {
        lvlText.text = currentLvl.ToString();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount>0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.touchCount > 0)
            {
                ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            }

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (canMove)
                {
                    objectHit = hit.transform.gameObject.GetComponent<InteractebleObjectScript>();

                    if (objectHit)
                    {
                        canMove = false;
                        objectHit.SelectObject();
                        TransitMovePlayer();
                    }
                }
            }
        }
    }

    private void TransitMovePlayer()
    {
        sequence = DOTween.Sequence();
        if (transform.position != objectHit.PointTransform.position) 
        {
            if (objectHit.TransitPointTransform)
            {
                sequence.Append(player.transform.DOLookAt(objectHit.TransitPointTransform.position, 0))
               .Append(transform.DOMove(objectHit.TransitPointTransform.position, 0.5f).SetEase(Ease.Linear));
            }

            sequence.Append(player.transform.DOLookAt(objectHit.PointTransform.position, 0))
                .Append(transform.DOMove(objectHit.PointTransform.position, 0.5f).SetEase(Ease.Linear)).OnComplete(Reset);
            anim.Play("Run");
            runAudio.Play();
        }
        else
        {
            Reset();
        }
    }

    private void Reset()
    {
        runAudio.Stop();
        anim.Play("Idle");
        var type = objectHit.ReturnType();
        if (type == InteractiveObjectType.Chest)
        {
            objectHit.Iteractive();
            anim.SetBool("Attack", true);
            AttackAudio.Play();
            TextAnimation(objectHit.ReturnLvLtext());
            cameraController.ShakeCamera();
        }
        if (type == InteractiveObjectType.Enemy)
        {
            if (objectHit.ReturnLvL() < currentLvl)
            {
                anim.SetBool("SuperAttack", true);
                cameraController.ShakeCamera();

            }
            else
            {
                objectHit.Attack();
                anim.SetBool("Death", true);
                HurtAudio.Play();
                cameraController.ShakeCamera();
            }
        }
    }

    private void TextAnimation( GameObject objectLvlText)
    {
        objectLvlText.transform.SetParent(textParent, true);
        objectLvlText.transform.DOLocalMove(lvlText.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            Destroy(objectLvlText);
            objectHit.DeleteObject();
            currentLvl += objectHit.ReturnLvL();
            lvlText.text = currentLvl.ToString();
            lvlText.transform.DOShakeScale(0.3f, 5, 1);
            lvlUpAudio.Play();  
            PlayerEffect();
            if (!canAttackWaterEnemy && objectHit.ReturnType() == InteractiveObjectType.Enemy)
            {
                cameraController.MakeNewSize(12);
                foreach (var item in waterEnemies)
                {
                    item.ActivePanel(); 
                }
                canAttackWaterEnemy = true;
            }
            if (objectHit.ReturnType() == InteractiveObjectType.Chest)
            {
                cameraController.ShakeCamera();
            }

        });
        canMove = true;

    }

    public void AfterFightLogic()
    {
        objectHit.DeathAnimation();
        TextAnimation(objectHit.ReturnLvLtext());

    }
    public void ResetAttackAnimation()
    {
        anim.SetBool("Attack", false);
        canMove = true;


    }
    public void ResetLvLUpAnimation()
    {
        anim.SetBool("UpLvL", false);
        canMove = true;


    }
    public void ResetSuperAttackAnimation()
    {
        anim.SetBool("SuperAttack", false);

    }
    private void PlayerEffect()
    {
        sequence.Kill();
        anim.SetBool("UpLvL", true);
        var effect = Instantiate(LvLUpEffect, new Vector3(0.22f, 1.38f, 0.51f), Quaternion.Euler(-28.301f, 41.828f, 0));
        effect.transform.SetParent(this.transform, false);
    }

}
