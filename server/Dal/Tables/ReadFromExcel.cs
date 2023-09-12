namespace DL.Tables;

public static class ReadFromExcel
{
    /// <summary>
    /// the function read excel files to DataTable
    /// </summary>
    /// <param name="strFilePath">Path to the file you want to read</param>
    /// <returns>DataTable that contains the data from excek file</returns>
    public static DataTable RaedToTable(string strFilePath)
    {
        DataTable dt = new DataTable();
        using (StreamReader sr = new StreamReader(strFilePath))
        {
            sr.ReadLine(); // Skip the title bar
            string[] headers = sr.ReadLine().Split(',');
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }

        }
        return dt;
    }


}
