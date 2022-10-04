using System;
using System.IO;
using InterfaceLayer;

namespace MainProcess
{

    public class FileReadWrite : ILoginData
    {
        FileStream fs;
        StreamReader sr;
        StreamWriter sw;

        string ErrorMessage = string.Empty;

        public void GetUserData(out string User, out string pass)
        {
            ReadData("UserName.txt" , out User);
            ReadData("Password.txt" , out pass);
        }
        public void SaveUserData(string User, string pass)
        {            
            WriteData("UserName.txt", User);
            WriteData("Password.txt", pass);
        }
        public void ReadData(string FileName , out string GetValue)
        {
            GetValue = null;

            try
            {
                string CurDir = Directory.GetCurrentDirectory() + FileName;
                // CurDir = CurDir.Replace("\\", "/");
                fs = new FileStream(CurDir, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                GetValue = sr.ReadLine();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                if (sr != null)
                    sr.Close();

                if (fs != null)
                    fs.Close();
            }
        }

        public void WriteData(string FileName, string GetValue)
        {
            try
            {
                string CurDir = Directory.GetCurrentDirectory() + FileName;
                // CurDir = CurDir.Replace("\\", "/");
                fs = new FileStream(CurDir, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(GetValue);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                if (sw != null)
                    sw.Close();

                if (fs != null)
                    fs.Close();
            }
        }
    }
}
