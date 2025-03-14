using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hitpoints : MonoBehaviour
{
    [SerializeField] private float _hitpoints = 3;
    [SerializeField] private float _maxhitpoints = -1;
    public float expYield = 1;
    private float _hittimer;
    private float _scalar;
    public Renderer renderer;
    public bool colorCycle = true;
    public bool triggeredDeath;
    private Color ogcolor;
    public Gradient hitcolor;
    public UnityEvent onDeath;
    public UnityEvent onHPchange;
    public Phase[] phases = new Phase[0];
    [System.Serializable] public class Phase
    {
        public string name;
        public int hp;
        public bool invoked;
        public UnityEvent startfunction;
        public void TriggerPhases(float _hitpoints)
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
    public float maxhitpoints
    {
        get => _maxhitpoints;
        set => _maxhitpoints = value;
    }

    public float hitpoints
    {
        get => _hitpoints;
        set
        {
            _hitpoints = value;
            onHPchange.Invoke();
            for (int i = 0; i < phases.Length; i++)
            {
                Phase p = phases[i];
                p.TriggerPhases(_hitpoints);
            }
            
            
            if (_hitpoints <= 0)
            {
                if(!triggeredDeath)
                {
                    
                    //Debug.Log("trigger score" + name);
                    ImportantVars.Instance.score += score;
                    triggeredDeath = true;
                    onDeath.Invoke();
                }
                else if (!haveComplainedDoubleDeath)
                {
                    // weird thing about the engine allows hitpoints to trigger twice
                    Debug.Log("not again >:(");
                    haveComplainedDoubleDeath = true;
                }
            }
        }
        
    }
    private static bool haveComplainedDoubleDeath;
    public void Start()
    {
        if(_maxhitpoints == -1)
        {
            _maxhitpoints = _hitpoints;
        }
        RecalculateRender();

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
            if(renderer == null)
            {
                return;
            }

            renderer.material.color = hitcolor.Evaluate(_hittimer * _scalar);
            if(_hittimer <= 0)
            {
                renderer.material.color = ogcolor;
            }        
        }
    }

    public void DebugPrint(string text)
    {
        Debug.Log(text);
    }
    
    public void RecalculateRender()
    {
        if (!colorCycle)
        {
            return;
        }
        renderer = GetComponentInChildren<Renderer>();
        if(renderer is LineRenderer)
        {
            renderer = null;
        }
        if(renderer == null)
        {
            return;
        }
        else
        {
            ogcolor = renderer.material.color;
        }
        
    }

    public void AddExpPoints()
    {
        ExpBar.Instance.AddExpPoints(expYield);
    }

}
