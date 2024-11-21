using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{

    public class XRThrowCube : GrabInteractableTwoAttach
    {
        #region Variables
        public float velocityMultiplier = 2.0f; // �ӵ��� ������Ű�� ����

        [SerializeField] private float force = 5f;
        #endregion

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            XRGrabInteractable grabInteractable =GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                // ��� ���� �̺�Ʈ�� �Լ� ���
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
                Debug.Log($"���� ={rb.angularVelocity}");
                rb.angularVelocity = rb.angularVelocity * velocityMultiplier * force;
                Debug.Log($"���� ={rb.angularVelocity}");
            }
        }
    }
}