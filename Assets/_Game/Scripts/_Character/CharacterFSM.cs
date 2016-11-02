
//#define FSMDEBUG
using UnityEngine;
using System.Collections;

//THIS FILE IS CREATED BY FSM EDITOR, MODIFIED BY PANWEIGUO
//COPYRIGHTS @ 2013 SIX DYNASTIES
//WWW.SIXDYNASTIES.COM WWW.MYCSOFT.NET

public class CharacterFSM {
	
public	enum State {
    	Attack,
    	Death,
    	Idle,
    	Run,
    	Skill
    };

public enum Event {
    	Attack,
    	Death,
    	Run,
    	Skill,
    	Stop_attack,
    	Stop_run,
    	Stop_skill
    };
	
	
public CharacterFSM() {
	_currentState = State.Idle;
	_lastState = _currentState;
}

#region delegate function




       public delegate void _OnAttackIn(object obj);
       public delegate void _OnAttackOut(object obj);
       public delegate void _OnDeathIn(object obj);
       public delegate void _OnDeathOut(object obj);
       public delegate void _OnIdleIn(object obj);
       public delegate void _OnIdleOut(object obj);
       public delegate void _OnRunIn(object obj);
       public delegate void _OnRunOut(object obj);
       public delegate void _OnSkillIn(object obj);
       public delegate void _OnSkillOut(object obj);
	
       public event _OnAttackIn OnAttackIn;
       public event _OnAttackOut OnAttackOut;
       public event _OnDeathIn OnDeathIn;
       public event _OnDeathOut OnDeathOut;
       public event _OnIdleIn OnIdleIn;
       public event _OnIdleOut OnIdleOut;
       public event _OnRunIn OnRunIn;
       public event _OnRunOut OnRunOut;
       public event _OnSkillIn OnSkillIn;
       public event _OnSkillOut OnSkillOut;

#endregion


	//get the current status name
    public string stateName(State state) {
		switch (state) {
			case State.Attack:
				return "Attack";
			case State.Death:
				return "Death";
			case State.Idle:
				return "Idle";
			case State.Run:
				return "Run";
			case State.Skill:
				return "Skill";
			}
			return "Unknown";
	}
	
	public State currentState() {
		return _currentState;
	}

    public State lastState() {
        return _lastState;
    }
	
    private State _currentState;
    private State _lastState;
    private State _backState; // after a short status change, the fsm will be set to this status.


    public State getBackState() {
        return _backState;
    }
    
    public State setBackState(State stat) {
        _backState = stat;
        return stat;
    }

    public void processEvent(Event events, object obj=null) {
			switch (_currentState) {
			case State.Attack:
				// stop_attack
				if ((events == Event.Stop_attack)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnAttackOut()");
		#endif
					if (OnAttackOut != null) OnAttackOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Attack -> Idle: stop_attack");
		#endif
                    _lastState = _currentState;
					_currentState = State.Idle;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnIdleIn()");
		#endif
					if (OnIdleIn != null) OnIdleIn(obj);
					break;
				}
				// death
				if ((events == Event.Death)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnAttackOut()");
		#endif
					if (OnAttackOut != null) OnAttackOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Attack -> Death: death");
		#endif
                    _lastState = _currentState;
					_currentState = State.Death;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnDeathIn()");
		#endif
					if (OnDeathIn != null) OnDeathIn(obj);
					break;
				}
				break;
			case State.Death:
				break;
			case State.Idle:
				// run
				if ((events == Event.Run)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnIdleOut()");
		#endif
					if (OnIdleOut != null) OnIdleOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Idle -> Run: run");
		#endif
                    _lastState = _currentState;
					_currentState = State.Run;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnRunIn()");
		#endif
					if (OnRunIn != null) OnRunIn(obj);
					break;
				}
				// attack
				if ((events == Event.Attack)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnIdleOut()");
		#endif
					if (OnIdleOut != null) OnIdleOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Idle -> Attack: attack");
		#endif
                    _lastState = _currentState;
					_currentState = State.Attack;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnAttackIn()");
		#endif
					if (OnAttackIn != null) OnAttackIn(obj);
					break;
				}
				// skill
				if ((events == Event.Skill)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnIdleOut()");
		#endif
					if (OnIdleOut != null) OnIdleOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Idle -> Skill: skill");
		#endif
                    _lastState = _currentState;
					_currentState = State.Skill;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnSkillIn()");
		#endif
					if (OnSkillIn != null) OnSkillIn(obj);
					break;
				}
				// death
				if ((events == Event.Death)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnIdleOut()");
		#endif
					if (OnIdleOut != null) OnIdleOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Idle -> Death: death");
		#endif
                    _lastState = _currentState;
					_currentState = State.Death;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnDeathIn()");
		#endif
					if (OnDeathIn != null) OnDeathIn(obj);
					break;
				}
				break;
			case State.Run:
				// stop_run
				if ((events == Event.Stop_run)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnRunOut()");
		#endif
					if (OnRunOut != null) OnRunOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Run -> Idle: stop_run");
		#endif
                    _lastState = _currentState;
					_currentState = State.Idle;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnIdleIn()");
		#endif
					if (OnIdleIn != null) OnIdleIn(obj);
					break;
				}
				// death
				if ((events == Event.Death)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnRunOut()");
		#endif
					if (OnRunOut != null) OnRunOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Run -> Death: death");
		#endif
                    _lastState = _currentState;
					_currentState = State.Death;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnDeathIn()");
		#endif
					if (OnDeathIn != null) OnDeathIn(obj);
					break;
				}
				break;
			case State.Skill:
				// stop_skill
				if ((events == Event.Stop_skill)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnSkillOut()");
		#endif
					if (OnSkillOut != null) OnSkillOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Skill -> Idle: stop_skill");
		#endif
                    _lastState = _currentState;
					_currentState = State.Idle;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnIdleIn()");
		#endif
					if (OnIdleIn != null) OnIdleIn(obj);
					break;
				}
				// death
				if ((events == Event.Death)) {
		#if FSMDEBUG
						Debug.Log("- CharacterFSM::OnSkillOut()");
		#endif
					if (OnSkillOut != null) OnSkillOut(obj);
		#if FSMDEBUG
					Debug.Log("- CharacterFSM::Skill -> Death: death");
		#endif
                    _lastState = _currentState;
					_currentState = State.Death;
		#if FSMDEBUG
					Debug.Log("- output CharacterFSM::OnDeathIn()");
		#endif
					if (OnDeathIn != null) OnDeathIn(obj);
					break;
				}
				break;
			}
	}	
};
