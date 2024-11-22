using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class con của Event Action, tạo ra Action kích hoạt chuyển động của Obstacle Cube
/// </summary>
public class InitializeObstacleCubeMovementAction : EventAction
{
    [SerializeField] private ObstacleCubeCtrl obstacleCubeCtrl;
    [SerializeField] private int loopToInitializeMovement = 3;

    private void Reset() {
        obstacleCubeCtrl = transform.parent.parent.GetComponent<ObstacleCubeCtrl>();
    }

    protected override UnityAction Act()
    {
        return () => ((ObstacleCubeMoveByPointYoyoLoop)obstacleCubeCtrl.obstacleCubeMovement).InitializeMovement(loopToInitializeMovement);
    }
}