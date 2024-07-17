namespace DataAccount
{
    public static class DataAccountPlayer
    {
        private static PlayerSettings _playerSettings;
        private static PlayerTutorialData _playerTutorialData;

        #region Getters



        public static PlayerSettings PlayerSettings
        {
            get
            {
                if (_playerSettings != null)
                {
                    return _playerSettings;
                }

                var playerSettings = new PlayerSettings();
                _playerSettings = ES3.Load(DataAccountPlayerConstants.PlayerSettings, playerSettings);
                return _playerSettings;
            }
        }


        public static PlayerTutorialData PlayerTutorialData
        {
            get
            {
                if (_playerTutorialData != null)
                    return _playerTutorialData;

                var playerTutorialData = new PlayerTutorialData();
                _playerTutorialData = ES3.Load(DataAccountPlayerConstants.PlayerTutorialData, playerTutorialData);
                return _playerTutorialData;
            }
        }

        #endregion

        #region Save

        public static void SavePlayerSettings()
        {
            ES3.Save(DataAccountPlayerConstants.PlayerSettings, _playerSettings);
        }

        public static void SavePlayerTutorialData()
        {
            ES3.Save(DataAccountPlayerConstants.PlayerTutorialData, _playerTutorialData);
        }

        #endregion
    }
}