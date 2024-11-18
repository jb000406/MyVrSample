using UnityEngine;

namespace MyFps
{

    public class Bullet : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float bulletDamage = 20f;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Enemy")
            {
                RobotController enemy = other.GetComponent<RobotController>();
                enemy.TakeDamage(bulletDamage);
            }
        }
    }
}