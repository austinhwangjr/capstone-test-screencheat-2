using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    void Enter();
    void Execute();
    void Exit();
}

public class StateMachine
{
    private State current_state_;
    private State previous_state_;
    private State global_state_;

    void ChangeState(State newstate)
    {
        if (current_state_ != null)
        {
            current_state_.Exit();
            previous_state_ = current_state_;
            current_state_ = newstate;
            current_state_.Enter();
        }
    }

    void Update()
    {
        if (current_state_ != null)
        {
            current_state_.Execute();
        }
        if (global_state_ != null)
        {
            global_state_.Execute();
        }
    }

    void RevertState()
    {
        ChangeState(previous_state_); 
    }

    bool IsInState(State state)
    {
        return state == current_state_;
    }
}

public class Enemy_Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
