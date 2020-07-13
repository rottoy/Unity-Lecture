using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;
        public void StartAction(IAction action)
        {
            //같은 행동이라면 cancel 필요 없으므로 반환
            if (currentAction == action) return ;

            //다른 행동
            //행동이 null이 아니라면,해당 행동에 대해 cancel 호출.
            //cancel은 interface를 통해 각 함수의 구현으로 리디렉션됨

            if (currentAction != null)
            {
                currentAction.Cancel();
                print("Cancelling" + currentAction);

              
            }

            //행동이 null이면 (=초기 상태였다면 일로 옴)
            
            currentAction = action;
        }
    }
}
