using System.Text;

namespace ExifExtracter
{
    public class Logger
    {
        string LogPath { get; set; }

        public Logger()
        {
            LogPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
        }

        public void OutputLog(List<string> list)
        {
            var infoString = new StringBuilder();
            foreach (var str in list)
            {
                infoString.Append(str);
                infoString.Append(Environment.NewLine);
            }

            string now = (DateTime.Now).ToString("yyyy-MM-dd-HH-mm-ss");
            File.AppendAllText(Path.Combine(LogPath, now + ".log"), infoString.ToString());
        }
    }
}
