using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleStates : MonoBehaviour
{
    [System.Serializable]
    public class State
    {
        public string name;
        public UnityEvent OnEnter;
        public UnityEvent OnExit;
        public UnityEvent OnExecute;
    }
    public State[] states;
    [SerializeField] private int _index = -1;
    public int Index
    {
        get => _index;
        set
        {
            if(_index >= 0 && _index < states.Length)
            {
                states[_index].OnExit.Invoke();
            }
            _index = value;
            if (_index >= 0 && _index < states.Length)
            {
                states[_index].OnEnter.Invoke();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        int correctIndex = _index;
        _index = -1;
        Index = correctIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (_index >= 0 && _index < states.Length)
        {
            states[_index].OnExecute.Invoke();
        }
    }
}
