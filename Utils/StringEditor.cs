namespace RePaint.Utils
{
    static class StringEditor
    {
        public static string FileNamePath(string fileFullName)
        {
            string fileNamePath;

            if (fileFullName.IndexOf('/') == 0)
            {
                fileNamePath = fileFullName.Remove(fileFullName.LastIndexOf('/'));
                return fileNamePath;
            }

            fileNamePath = fileFullName.Remove(fileFullName.LastIndexOf('\\'));
            return fileNamePath;
        }

        public static string FileNameExt(string fileFullName)
        {
            string fileNameExt;

            if (fileFullName.IndexOf('/') == 0)
            {
                fileNameExt = fileFullName.Substring(fileFullName.LastIndexOf('/') + 1);
                return fileNameExt;
            }

            fileNameExt = fileFullName.Substring(fileFullName.LastIndexOf('\\') + 1);
            return fileNameExt;
        }

    }
}
