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


    public void AI_Barge()
    {
        FunctionTimer.Create(() => boss.NewMovementAndRotation(new Vector2(0, -3.5f), 1), 1);
        //boss.NewMovementAndRotation(new Vector2(0, -1.5f), 1);

    }


}
