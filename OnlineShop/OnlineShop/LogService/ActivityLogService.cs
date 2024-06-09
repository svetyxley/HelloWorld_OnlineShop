using OnlineShop.Constants;
namespace OnlineShop.Records
{
    public class ActivityLogService
    {
        public void OutputLog(ActivityLog log) 
        {
            using (StreamWriter writer = new StreamWriter(PathConstants.LOG_PATH, true))
            {
                writer.WriteLine(log.ToString());
            }
        }
    }
}