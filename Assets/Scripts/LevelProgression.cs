using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelProgression
{
    public string name;
    public Roster[] rosters;
    public LevelProgression(params Roster[] rosters)
    {
        this.rosters = rosters;
    }
    public LevelProgression(LevelProgression toCopy)
    {
        this.name = toCopy.name;
        this.rosters = new Roster[toCopy.rosters.Length];
        for(int i = 0; i < rosters.Length; i++)
        {
            rosters[i] = new Roster(toCopy.rosters[i]);
        }
    }
    [System.Serializable]
    public class Roster
    {
        [HideInInspector]
        public string name;
        public GameObject subject;
        public int minCount;
        public int maxCount;
        public Roster(Roster toCopy)
        {
            this.name = toCopy.name;
            this.subject = toCopy.subject;
            this.minCount = toCopy.minCount;
            this.maxCount = toCopy.maxCount;
        }
        public Roster(int min, int max, GameObject subject)
        {
            minCount = min;
            maxCount = max;
            this.subject = subject;
        }
        public static implicit operator Roster((int min, int max, GameObject subject)tuple)
        {
            return new Roster(tuple.min, tuple.max, tuple.subject);
        }
        public void OnValidate()
        {
            if(subject != null)
            {
                name = subject.name + $"({minCount},{maxCount})";
            }
        }
    }
    public void OnValidate()
    {
        for(int i = 0; i<rosters.Length; i++)
        {
            rosters[i].OnValidate();
        }
    }
    
}
