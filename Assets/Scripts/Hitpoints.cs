using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hitpoints : MonoBehaviour
{
    [SerializeField] private int _hitpoints = 3;
    private float _hittimer;
    private float _scalar;
    private Renderer renderer;
    private Color ogcolor;
    public Gradient hitcolor;
    public UnityEvent onDeath;
    public Phase[] phases = new Phase[0];
    [System.Serializable] public class Phase
    {
        public string name;
        public int hp;
        public bool invoked;
        public UnityEvent startfunction;
        public void TriggerPhases(int _hitpoints)
        {
            if (invoked || _hitpoints > hp)
            {
                return;
            }
            invoked = true;
            startfunction.Invoke();
        }
    }

    public int score = 300;
    public float hittimer
    {
        get
        {
            return _hittimer;
        }
        set
        {
            _hittimer = value;
            _scalar = 1 / value;
        }
    }
    public int hitpoints
    {
        get => _hitpoints;
        set
        {
            _hitpoints = value;
            for (int i = 0; i < phases.Length; i++)
            {
                Phase p = phases[i];
                p.TriggerPhases(_hitpoints);
            }
            
            
            if (_hitpoints <= 0)
            {
                onDeath.Invoke();
                ImportantVars.Instance.score += score;
            }
        }
        
    }
    public void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        ogcolor = renderer.material.color;
    }
    public void Update()
    {
        if(_hittimer <= 0)
        {
            return;
        }
        else
        {
            _hittimer -= Time.deltaTime;
            //if(renderer.material.color == ogcolor)
            //{
            //    renderer.material.color = Color.red;
            //}
            //else
            //{
            //    renderer.material.color = ogcolor;
            //}
            renderer.material.color = hitcolor.Evaluate(_hittimer * _scalar);
        }
    }

    public void DebugPrint(string text)
    {
        Debug.Log(text);
    }
    

}
