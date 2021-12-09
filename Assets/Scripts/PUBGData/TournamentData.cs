using System;
using TMPro;
using UnityEngine;

namespace PUBGData
{
    public class TournamentData : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tournamentId;
        [SerializeField] private TextMeshProUGUI _tournamentDate;
        [SerializeField] private TextMeshProUGUI _tournamentHour;

        public void Init(string id, string date)
        {
            _tournamentId.text = id;
            DateTime tournamentDate = DateTime.Parse(date);
            _tournamentDate.text = $"{tournamentDate.Year}/{tournamentDate.Month}/{tournamentDate.Day}";
            _tournamentHour.text = $"{tournamentDate.Hour}:{tournamentDate.Minute}";
        }
    } 
}

