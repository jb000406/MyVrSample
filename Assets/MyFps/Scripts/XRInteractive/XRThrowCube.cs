using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{

    public class XRThrowCube : GrabInteractableTwoAttach
    {
        #region Variables
        public float velocityMultiplier = 2.0f; // 속도를 증가시키는 배율

        [SerializeField] private float force = 5f;
        #endregion

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            XRGrabInteractable grabInteractable =GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                // 잡기 해제 이벤트에 함수 등록
                grabInteractable.selectExited.AddListener(OnSelectExited);
            }
        }



        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            DoAction();
        }

        protected override void DoAction()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if(rb != null )
            {
                rb.AddForce(Vector3.forward * force * Time.deltaTime, ForceMode.Force);
                Debug.Log($"현재 ={rb.angularVelocity}");
                rb.angularVelocity = rb.angularVelocity * velocityMultiplier * force;
                Debug.Log($"나중 ={rb.angularVelocity}");
            }
        }
    }
}