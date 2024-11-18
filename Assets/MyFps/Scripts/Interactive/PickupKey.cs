using UnityEngine;

namespace MyFps
{
    public class PickupKey : Interactive
    {
        #region Variables
        #endregion

        public override void DoAction()
        {
            //key Item 저장
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.ROOM01_KEY);

            //킬
            Destroy(gameObject);
        }
    }
}
