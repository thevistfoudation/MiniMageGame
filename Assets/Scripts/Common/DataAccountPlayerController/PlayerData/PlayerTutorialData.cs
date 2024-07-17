namespace DataAccount
{
    public class PlayerTutorialData
    {
        public bool unlockDaily = true;
        public bool unlockSpin = true;
        public bool unlockSkin = true;
        public bool firstTimeBattle = true;
        public bool firstTimeRevive = true;
        public int numberDead;
        public bool unlockUpgrade = false;
        public bool firstTimeUpgrade = true;
        public bool firstMove = true;
        public bool attack = true;
        public bool throwWeapon = true;
        public bool countRevivePlay = true;
        public int countPlayGame = 0;

        public void ChangeCountPlayGame()
        {
            countPlayGame += 1;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeMoveFirst(bool value)
        {
            firstMove = false;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeAttackFirst(bool value)
        {
            attack = false;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeThroWWeapFirst(bool value)
        {
            throwWeapon = false;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeReviveValue(bool value)
        {
            firstTimeRevive = value;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeValueUpgradeFirstTime(bool value)
        {
            firstTimeUpgrade = value;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeUpgradeValue(bool value)
        {
            unlockUpgrade = value;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeValueEndGame()
        {
            numberDead += 1;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void changeFirstTimeBattle(bool value)
        {
            firstTimeBattle = value;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeDailyValue(bool value)
        {
            unlockDaily = value;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeSpinValue(bool value)
        {
            unlockSpin = value;
            DataAccountPlayer.SavePlayerTutorialData();
        }

        public void ChangeSkinValue(bool value)
        {
            unlockSkin = value;
            DataAccountPlayer.SavePlayerTutorialData();
        }
    }
}
