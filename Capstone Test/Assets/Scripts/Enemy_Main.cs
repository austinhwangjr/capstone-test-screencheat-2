using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void Enter(ref Enemy_Main gameobject);
    public abstract void Execute(ref Enemy_Main gameobject);
    public abstract void Exit(ref Enemy_Main gameobject);
}

public class StateMachine
{
    public State current_state_;
    public State previous_state_;
    public State global_state_;
    private Enemy_Main owner_;

    public StateMachine(Enemy_Main owner)
    {
        owner_ = owner;
        current_state_ = new Idle();
    }

    public void ChangeState(State newstate)
    {
        if (current_state_ != null)
        {
            current_state_.Exit(ref owner_);
            Debug.Log("reached");
            previous_state_ = current_state_;
            current_state_ = newstate;
            current_state_.Enter(ref owner_);
        }
    }

    public void Update()
    {
        if (current_state_ != null)
        {
            current_state_.Execute(ref owner_);
        }
        if (global_state_ != null)
        {
            global_state_.Execute(ref owner_);
        }
    }

    public void RevertState()
    {
        ChangeState(previous_state_); 
    }

    public bool IsInState(State state)
    {
        return state == current_state_;
    }

    public void InitState(State state)
    {
        current_state_ = state;
    }
}

public class Idle : State
{
    public override void Enter(ref Enemy_Main gameobject)
    {
        Debug.Log("idle state entered");
    }
    public override void Execute(ref Enemy_Main gameobject)
    {
        GameObject game_object = GameObject.Find("Player 1");
        if (game_object != null)
        {
            gameobject.target_ = game_object;
            gameobject.state_machine_.ChangeState(new Chase());
        }
    }
    public override void Exit(ref Enemy_Main gameobject)
    {
    }
}

public class Chase : State
{
    public override void Enter(ref Enemy_Main gameobject)
    {
        if (gameobject.target_ == null)
        {
            gameobject.state_machine_.ChangeState(new Idle());
        }
    }
    public override void Execute(ref Enemy_Main gameobject)
    {
        if (gameobject.target_ != null)
        {
            
        }
    }
    public override void Exit(ref Enemy_Main gameobject)
    {
    }
}

public class Enemy_Main : MonoBehaviour
{
    public StateMachine state_machine_;
    public GameObject target_;

    // Start is called before the first frame update
    void Start()
    {
        state_machine_ = new StateMachine(this);
        //state_machine_.InitState(new Idle());
        Debug.Log(state_machine_.current_state_);
    }

    // Update is called once per frame
    void Update()
    {
        state_machine_.Update();
    }
}
