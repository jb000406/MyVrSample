using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFps
{
    //인터렉티브 액션을 구현하는 클래스
    public abstract class Interactive : MonoBehaviour
    {
        public abstract void DoAction();

        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

        public InputActionProperty leftActivate;    //왼쪽 컨트롤러의 Activate 입력
        public InputActionProperty rightActivate;   //오른쪽 컨트롤러의 Activate 입력

        //true이면 Interactive 기능을 정지
        protected bool unInteractive = false;
        #endregion

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;

            float leftActivateValue = leftActivate.action.ReadValue<float>();
            float rightActivateValue = rightActivate.action.ReadValue<float>();

            if(leftActivateValue > 0 || rightActivateValue > 0)
            {
                DoAction();
            }

        }



        private void OnMouseOver()
        {
            //거리가 2이하 일때
            if (theDistance <= 2f && !unInteractive)
            {
                ShowActionUI();

                /*if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    //Action
                    DoAction();
                }*/
            }
            else
            {
                HideActionUI();
            }
        }

        private void OnMouseExit()
        {
            HideActionUI();
        }

        public void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        public void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }
    }
}