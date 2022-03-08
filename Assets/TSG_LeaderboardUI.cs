namespace TSG.Game
{
    using TSG.Model;
    using UnityEngine;

    public class TSG_LeaderboardUI : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] int maxHighscoresDataToDisplayCount = 10;

        [Header("XD")]
        [SerializeField] TSG_LeaderboardEntryUI highscoreUIPrefab = null;

        TSG_LeaderboardEntryUI[] highscoreDataUIs = new TSG_LeaderboardEntryUI[0];

        [Header("References")]
        [SerializeField] RectTransform highscoresContainer = null;

        private void Awake()
        {
            highscoreDataUIs = new TSG_LeaderboardEntryUI[maxHighscoresDataToDisplayCount];
        }

        public void OnHighscoreDataUpdate(TSG_GameEventData _gameEventData)
        {
            int _highscoreId = _gameEventData.IntValues[0];
            LeaderboardEntryModel _highscoreData = _gameEventData.ObjectValues[0] as LeaderboardEntryModel;

            if (_highscoreId < 0 && _highscoreId >= highscoreDataUIs.Length)
            {
                return;
            }

            if (highscoreDataUIs[_highscoreId] == null)
            {
                highscoreDataUIs[_highscoreId] = Instantiate(highscoreUIPrefab, highscoresContainer);
            }

            highscoreDataUIs[_highscoreId].Setup(_highscoreId, _highscoreData);
        }
    }
}