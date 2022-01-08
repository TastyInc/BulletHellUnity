using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAIs
{

    private Boss boss;

    public void Setup(Boss boss) {
        this.boss = boss;

        switch (GameMaster.GM.currentLevel) {
            case 1:
                AI_Barge();
                break;
        
        }

    }

    #region Barge
    public void AI_Barge()
    {
        FunctionTimer.Create(() => boss.NewMovementAndRotation(new Vector2(0, -1.5f), 1), 0);
        FunctionTimer.Create(() => boss.NewMovementAndRotation(new Vector2(0, 0), 7.7f), 7.2f);
        FunctionTimer.Create(() => boss.NewMovementAndRotation(new Vector2(0.75f, -0.5f), 1), 7.5f);
        FunctionTimer.Create(() => boss.NewMovementAndRotation(new Vector2(0.75f, -0.5f), -1.2f), 23.5f);
        FunctionTimer.Create(() => boss.NewMovementAndRotation(new Vector2(-3.5f, -0.5f), 1), 38.5f);
        
        FunctionTimer.Create(() => boss.NewMovementAndRotation(new Vector2(0, -3f), 2), 68.5f);
        FunctionTimer.Create(() => boss.NewMovementAndRotation(new Vector2(5f, 0), 3), 80);
        FunctionTimer.Create(() => boss.NewMovement(new Vector2(1f, 3f)), 100);

    }
    #endregion


}
