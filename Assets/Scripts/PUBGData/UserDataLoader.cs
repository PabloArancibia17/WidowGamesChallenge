using System.Collections;
using TMPro;
using UnityEngine;

namespace PUBGData
{
    public class UserDataLoader : MonoBehaviour
    {
        [SerializeField] private Data _tournamentData;
        [SerializeField] private TournamentData _tournamentTextGO;
        [SerializeField] private PUBGService _pubgService;
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _loadingGO;

        private const string Loading = "Loading...";

        public void OnClicked()
        {
            _loadingGO.GetComponent<TextMeshProUGUI>().text = Loading;
            StartCoroutine(FillDataTournament());
        }
        
        private IEnumerator FillDataTournament()
        {
            yield return _pubgService.GetAPI();

            if (_pubgService.SuccesfullResult)
            {
                _tournamentData.Clear();

                foreach (var data in _tournamentData.TouramentData)
                {
                    var tournamentDataInstance = Instantiate(_tournamentTextGO, _content);
                    tournamentDataInstance.Init(data.Id, data.Date);
                }
            
                _loadingGO.SetActive(false);
            }
        }
    }
}

