
using FoodFusion;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения
        public int Score;
        public FoodDatasPack DataPack;

        public SavesYG()
        {
            Score = 0;
            DataPack = null;
        }
    }
}
