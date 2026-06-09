    using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
    {
        internal class AnimController : MonoBehaviour
        {
            [SerializeField] private PlayerController playerController;

        public void ResetAttack()
        {
            playerController.ResetAttackAnimation();
        }

        public void ResetUpdate()
        {
            playerController.ResetLvLUpAnimation();
        }
        public void ResetSuperAttack()
        {
            playerController.ResetSuperAttackAnimation();
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }

        public void AfterAttack()
        {
            playerController.AfterFightLogic();
        }
        public void ResetLvL()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    }
