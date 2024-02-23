using System.Diagnostics;
using System.Drawing.Imaging;

namespace ExifExtracter
{
    public class ExifReader
    {
        private List<ExifData> exifDataList = new List<ExifData>();

        public List<ExifData> GetExifDataList(string path)
        {
            ReadDirectory(path);
            return exifDataList;
        }

        private void ReadDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (var filePath in files)
                {
                    ReadExifData(filePath);
                }

                string[] dirs = Directory.GetDirectories(path);
                foreach (var dirPath in dirs)
                {
                    ReadDirectory(dirPath);
                }
            }            
        }

        private void ReadExifData(string path)
        {
            if (!IsImage(path))
            {
                return;
            }

            var exifData = new ExifData();
            exifData.Path = path;
            exifData.Name = Path.GetFileName(path);

            using (var bmp = new Bitmap(path))
            {
                foreach (var item in bmp.PropertyItems)
                {
                    switch (item.Id)
                    {
                        // PropertyTagGpsLatitudeRef
                        //case 0x0001:
                        //    ReadLatlngRef(item);
                        //    break;

                        // PropertyTagGpsLatitude
                        case 0x0002:
                            exifData.Lat = ReadLatlng(item);
                            break;

                        // PropertyTagGpsLongitudeRef
                        //case 0x0003:
                        //    ReadLatlngRef(item);
                        //    break;

                        // PropertyTagGpsLongitude
                        case 0x0004:
                            exifData.Lng = ReadLatlng(item);
                            break;
                    }

                    if (exifData.Lat > 0 && exifData.Lng > 0)
                    {
                        break;
                    }
                }

                exifDataList.Add(exifData);
            }
        }

        private bool IsImage(string path)
        {
            string[] AllowImageFileExtension = 
                { ".jpg", ".JPG", ".gif", ".GIF", ".png", ".PNG", ".jpeg", ".JPEG", ".bmp", ".BMP" };
            string fileType = Path.GetExtension(path);

            return AllowImageFileExtension.Contains(fileType);
        }

        /// <summary>
        /// 緯度・経度を60進数（度分秒）から10進数に変換
        /// </summary>
        /// <param name="deg"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        /// <returns></returns>
        private decimal ConvertLatlngFrom60To10(decimal deg, decimal min, decimal sec)
        {
            decimal latLng = deg + (min / 60) + (sec / 60 / 60);
            return Math.Round(latLng, 10);
        }

        private void ReadLatlngRef(PropertyItem item)
        {
            string value = System.Text.Encoding.ASCII.GetString(item.Value);
            value = value.Trim(new char[] { '\0' });

            switch(value)
            {
                case "N":
                    Debug.Print("北緯");
                    break;
                case "S":
                    Debug.Print("南緯");
                    break;
                case "E":
                    Debug.Print("東経");
                    break;
                case "W":
                    Debug.Print("西経");
                    break;
            }
        }

        private decimal ReadLatlng(PropertyItem item)
        {
            UInt32 deg_numerator = BitConverter.ToUInt32(item.Value, 0);
            UInt32 deg_denominator = BitConverter.ToUInt32(item.Value, 4);
            decimal deg = (decimal)deg_numerator / (decimal)deg_denominator;

            UInt32 min_numerator = BitConverter.ToUInt32(item.Value, 8);
            UInt32 min_denominator = BitConverter.ToUInt32(item.Value, 12);
            decimal min = (decimal)min_numerator / (decimal)min_denominator;

            UInt32 sec_numerator = BitConverter.ToUInt32(item.Value, 16);
            UInt32 sec_denominator = BitConverter.ToUInt32(item.Value, 20);
            decimal sec;
            if (sec_denominator == 0)
            {
                sec = 0;
            }
            else
            {
                sec = (decimal)sec_numerator / (decimal)sec_denominator;
            }

            //Debug.Print($"{deg}度{min}分{sec}秒\r\n");
            //Debug.Print(ConvertLatlngFrom60To10(deg, min, sec).ToString());

            return ConvertLatlngFrom60To10(deg, min, sec);
        }
    }
}
