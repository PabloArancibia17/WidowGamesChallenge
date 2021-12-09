using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace PUBGData
{
  public class PUBGService : MonoBehaviour
  {
      //[SerializeField] private UserDataLoader _userDataLoader;
      //[SerializeField] private GameObject _loadingGO;
      [SerializeField] private Data _tournamentData;
      [SerializeField] private TextMeshProUGUI _errorText;
      public bool SuccesfullResult;

      
      public IEnumerator GetAPI()
      {
          string uri = "https://api.pubg.com/tournaments";
          using UnityWebRequest request = UnityWebRequest.Get(uri);
          request.SetRequestHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJjMGEwZTllMC0zNWJmLTAxM2EtMThiOC03YjQwOGZmNzE2YjciLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjM4NDY0NjMzLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6IndpZG93dGVzdGluZ3ByIn0.LV4Xd-NnS7KQH6ccscLkB9sPVsXCDLtvW5YayKGh3I8");
          request.SetRequestHeader("Accept", "application/vnd.api+json");
  
          yield return request.SendWebRequest();
          Debug.Log(request.result);
          
          if (request.result == UnityWebRequest.Result.ConnectionError ||
              request.result == UnityWebRequest.Result.ProtocolError)
          {
              SuccesfullResult = false;
              Debug.LogError(request.error);
              _errorText.text = request.error;
          }
          else
          {
              SuccesfullResult = true;
              
              var myJSONString = request.downloadHandler.text;
              
              UserData userData = JsonConvert.DeserializeObject<UserData>(myJSONString);

              if (userData != null)
              {
                  _tournamentData.Clear();
                  
                  foreach (var data in userData.data)
                  {
                      _tournamentData.TournamentId.Add(data.id);
                      _tournamentData.TournamentDate.Add(data.attributes.createdAt);
                      _tournamentData.TouramentData.Add(new ObjectData{Id = data.id, Date = data.attributes.createdAt});
                  }
              }
          }
      }
      
      public class UserData
      {
          public Links links { get; set; }
          public List<Data> data { get; set; }
  
  
          public class Links
          {
              public string self { get; set; }
          }
  
          public class Data
          {
              public string type { get; set; }
              public string id { get; set; }
              public DataAttributes attributes { get; set; }
          }
  
          public class DataAttributes
          {
              public string createdAt { get; set; }
          }
      }
  }  
}

