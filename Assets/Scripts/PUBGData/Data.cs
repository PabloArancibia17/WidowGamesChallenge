using System.Collections.Generic;
using UnityEngine;

namespace PUBGData
{
    public class ObjectData
    {
        public string Id;
        public string Date;
    }
    
    [CreateAssetMenu(fileName = "ScriptableData", menuName = "DATA", order = 0)]
    public class Data : ScriptableObject
    {
        [SerializeField] public List<string> TournamentId;
        [SerializeField] public List<string> TournamentDate;
        public List <ObjectData> TouramentData = new List<ObjectData>();
        
        public void Clear()
        {
            TournamentId.Clear();
            TournamentDate.Clear();
        }
    } 
}

