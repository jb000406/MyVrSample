using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVrSample
{
    /// <summary>
    /// ±ÇÃÑ ÃÑ¾Ë ¹ß»ç
    /// </summary>
    public class FireBulletOnActivate : MonoBehaviour
    {
        #region Variables
        public GameObject bulletPrefab;

        public Transform firePoint;

        public float bulletSpeed = 20f;
        #endregion

        public void Start()
        {
            XRGrabInteractable xRGrabInteractable = GetComponent<XRGrabInteractable>();
            xRGrabInteractable.activated.AddListener(Fire);
        }

        void Fire(ActivateEventArgs args)
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletGo.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
            Destroy(bulletGo, 5f);
        }

    }
}