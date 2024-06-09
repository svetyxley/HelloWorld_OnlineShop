using OnlineShop.Constants;

namespace OnlineShop.Records
{
    public class ActivityLogService
    {
        public void OutputLog(ActivityLog log)
        {
            FileInfo fileInfo = new FileInfo(FileConstants.LOG_PATH);

            // Якщо файл не існує, створюємо його
            if (!File.Exists(FileConstants.LOG_PATH)) 
            {
                using (FileStream fs = File.Create(FileConstants.LOG_PATH));
            }

            // Якщо розмір файлу більше MAX_FILE_SIZE, очищаємо файл
            if (fileInfo.Length > FileConstants.MAX_FILE_SIZE)
            {
                File.WriteAllText(FileConstants.LOG_PATH, string.Empty);
            }

            using (StreamWriter writer = new StreamWriter(FileConstants.LOG_PATH, true))
            {
                writer.WriteLine(log.ToString());
            }
        }
    }
}