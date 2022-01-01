using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionTimer
{
    private static List<FunctionTimer> activeTimerList;
    private static GameObject initGameObject;

    private static void initIfNeeded() {
        if (initGameObject == null) {
            initGameObject = new GameObject("FunctionTimer_InitGameObject");
            activeTimerList = new List<FunctionTimer>();
        }
    }

    public static FunctionTimer Create(UnityAction action, float timer, string timerName = null) {
        initIfNeeded();

        GameObject go = new GameObject("FunctionTimer", typeof(MonoBehav));

        FunctionTimer functionTimer = new FunctionTimer(action, timer, timerName, go);

        go.GetComponent<MonoBehav>().onUpdate = functionTimer.Update;

        activeTimerList.Add(functionTimer);

        return functionTimer;
    }

    private static void RemoveTimer(FunctionTimer functionTimer) {
        initIfNeeded();
        activeTimerList.Remove(functionTimer);   
    }


    //Use FunctionTimer.StopTimer(NAME) to stop this one. 
    private static void StopTimer(string timerName) {
        for (int i = 0; i < activeTimerList.Count; i++) {
            if (activeTimerList[i].timerName == timerName) {
                //Stop this timer!
                activeTimerList[i].DestroySelf();
                i--;
            }
        }
    }

    //Dummi class for monoscheiss
    public class MonoBehav : MonoBehaviour {
        public UnityAction onUpdate;

        private void Update()
        {
            if (onUpdate != null) {
                onUpdate();
            }
        }
    }

    private UnityAction action;
    private float timer;
    private string timerName;
    private GameObject gameObject;
    private bool isDestroyed;

    private FunctionTimer(UnityAction action, float timer, string timerName, GameObject gameObject) {
        this.action = action;
        this.timer = timer;
        this.timerName = timerName;
        this.gameObject = gameObject;

        isDestroyed = false;
    }


    // Update is called once per frame
    public void Update()
    {
        if (!isDestroyed) {
            timer -= Time.deltaTime;
            if (timer < 0) {
                action();
                DestroySelf();
            }
        }
    }

    private void DestroySelf() {
        isDestroyed = true;
        Object.Destroy(gameObject);
        RemoveTimer(this);
    }
}
