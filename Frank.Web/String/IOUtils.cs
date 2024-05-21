using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Web.String
{
    public static class IOUtils
    {
        public static bool IsFolderExisted(this string folderPath)
        {
            var result = System.IO.Directory.Exists(folderPath);
            return result;
        }

        public static bool IsFileExisted(this string filePath)
        {
            var result = System.IO.File.Exists(filePath);
            return result;
        }

        public static bool InitFolder(this string folderPath)
        {
            var result = true;
            try
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public static bool RemoveFile(this string filePath)
        {
            var result = true;
            try
            {
                System.IO.File.Delete(filePath);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
