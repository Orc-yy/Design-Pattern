using System.Collections.Generic;
using UnityEngine;

public enum EState
{
    Idle,
    Walk
}
public abstract class StateBase : MonoBehaviour
{
    public EState eState;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void UpdateState();
}

public class StateManager : MonoBehaviour
{
    [SerializeField]
    EState curState;
    [SerializeField]
    StateBase[] stateBases;

    Dictionary<EState, StateBase> stateDic;

    public void TransitionTo(EState State1)
    {
        if (curState == State1) return;

        stateDic[curState].Exit();
        curState = State1;
        stateDic[State1].Enter();

    }
    private void Awake()
    {
        stateDic = new();
        foreach (StateBase stateBase in stateBases)
        {
            stateDic.TryAdd(stateBase.eState, stateBase);
        }
        stateDic[curState].Enter();
    }
    private void Update()
    {
        stateDic[curState].UpdateState();
    }
}
