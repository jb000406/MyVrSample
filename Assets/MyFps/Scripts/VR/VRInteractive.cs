using TMPro;
using UnityEngine;

namespace VR
{

    public abstract class VRInteractive : MonoBehaviour
    {
        public abstract void DoAction();

        #region Variables
        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

        //true이면 Interactive 기능을 정지
        protected bool unInteractive = false;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}