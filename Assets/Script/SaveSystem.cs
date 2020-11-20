using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace WBmap {
    public class SaveSystem
    {

        #region Singleton
        private static SaveSystem instance = new SaveSystem();
        public static SaveSystem Instance => instance;
        #endregion
        private SaveSystem() { }

        //public string path => Application.dataPath + "/Resources/StageStar.json";
        //public string path => Path.Combine(Application.persistentDataPath, "StageStar.json");
        public string path => Path.Combine(Application.dataPath, "StageStar.json");
        private StageStarData starData = new StageStarData();
        public StageStarData StarData => starData;

        public void Save()
        {
            string jsonData = JsonUtility.ToJson(starData);
            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(jsonData);
            writer.Flush();
            writer.Close();
        }

        public void Load()
        {
            if (!File.Exists(path))
            {
                Debug.Log("ファイルが見つかりません");
                return;
            }

            StreamReader reader = new StreamReader(path);
            string jsonData = reader.ReadToEnd();
            starData = JsonUtility.FromJson<StageStarData>(jsonData);
            reader.Close();
        }
    }
}