using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField]
    private int _teamID = 1;
    public int teamID
    {
        get
        {
            return _teamID;
        }
        set
        {
            RemoveTeamMember(this);
            _teamID = value;
            AddTeamMember(this);
        }
    }

    public static Dictionary<int, List<Team>> AllTheRosters = new Dictionary<int, List<Team>>();

    public static void AddTeamMember(Team teamMember)
    {
        if (!AllTheRosters.TryGetValue(teamMember.teamID, out List<Team> roster))
        {
            roster = new List<Team>();
            AllTheRosters[teamMember.teamID] = roster;
        }
        roster.Add(teamMember);
    }

    public static void RemoveTeamMember(Team teamMember)
    {
        if (!AllTheRosters.TryGetValue(teamMember.teamID, out List<Team> roster))
        {
            return;
        }
        roster.Remove(teamMember);
    }

    public static List<Team> GetRoster(int teamID)
    {
        if (!AllTheRosters.TryGetValue(teamID, out List<Team> roster))
        {
            roster = new List<Team>();
            AllTheRosters[teamID] = roster;
        }
        return roster;
    }

    private void Start()
    {
        AddTeamMember(this);
    }
    private void OnDestroy()
    {
        //Debug.Log(name);
        RemoveTeamMember(this);
    }
}
