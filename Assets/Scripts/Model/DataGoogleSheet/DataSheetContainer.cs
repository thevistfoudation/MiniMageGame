using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NorskaLib.Spreadsheets;

namespace jinLab.Model
{
    [CreateAssetMenu(fileName = "SpreadsheetsContainer", menuName = "SpreadsheetsContainer")]
    public class DataSheetContainer : SpreadsheetsContainerBase
    {
        [SpreadsheetContent]
        [SerializeField] SpreadsheetContent content;
        public SpreadsheetContent Content => content;
    }

    [System.Serializable]
    public class SpreadsheetContent
    {
        [SpreadsheetPage("Player")]
        public List<PlayerData> playerData;
        [SpreadsheetPage("BulletPlayer")]
        public List<BulletPlayerData> bulletPlayerData;
        [SpreadsheetPage("Enemy")]
        public List<EnemyData> enemyData;
        [SpreadsheetPage("ArcData")]
        public List<ArcData> arcData;

    }


    [System.Serializable]
    public class PlayerData
    {
        public float speed;
        public float hp;
        public float timeShoot;
    }

    [System.Serializable]
    public class BulletPlayerData
    {
        public float speed;
        public float damage;
        public float bounceMax;
        public float penetrationMax;
        public float time;
        public float timeDamage;
    }

    [System.Serializable]
    public class EnemyData
    {
        public float speed;
        public float hp;
        public float damage;
    }


    [System.Serializable]
    public class ArcData
    {
        public float distance;
        public float damage;
        public float time;
    }

}

