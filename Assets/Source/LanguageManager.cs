using System.Collections.Generic;

public class LanguageManager : PSingleton<LanguageManager>
{
    protected const string CONFIG_PATH = "LanguageConfig";

    protected Dictionary<string, string> mConfigMap = new Dictionary<string, string>();

   
    public string GetText(string key, string defaultValue)
    {
        string ret = null;
        if(mConfigMap.TryGetValue(key, out ret))
        {
            return ret;
        }
        return defaultValue;
    }

       
    protected override void Init()
    {
        CsvFile file =  FileUtility.LoadCsvFile(CONFIG_PATH);
        if(file != null)
        {
            string key;
            string content;
            int row = file.RecordCount;
            for (int i = 0; i < row; i++)
            {
                key = file[i].GetString(0, "--key");
                content = file[i].GetString(1, "--content");
                    mConfigMap[key] = content;
            }
        }
    }
}