namespace DL.Tables;

public class AgeCoefficients
{
    static string PATH = "../../../מקדמי גיל.csv";
    public Dictionary<double, string> MarriedMan { get; }
    public Dictionary<double, string> UnMarriedMan { get; }
    public Dictionary<double, string> MarriedWoman { get; }
    public Dictionary<double, string> UnMarriedWoman { get; }


    /// <summary>
    /// The ctor initializes the 4 dictionaries with the values it receives from data tables. 
    /// Key: age of the employee, 
    /// value: Age coefficient according to gender and marital status.
    /// Singleton class.
    /// </summary>
    public AgeCoefficients()
    {
        MarriedMan = new Dictionary<double, string>();
        UnMarriedMan = new Dictionary<double, string>();
        MarriedWoman = new Dictionary<double, string>();
        UnMarriedWoman = new Dictionary<double, string>();

        DataTable dataTable = ReadFromExcel.RaedToTable(PATH);

        foreach (DataRow row in dataTable.Rows)
        {
            MarriedMan.Add(Convert.ToInt16(row[0]), Convert.ToString(row[2]));
            UnMarriedMan.Add(Convert.ToInt16(row[0]), Convert.ToString(row[1]));
            MarriedWoman.Add(Convert.ToInt16(row[0]), Convert.ToString(row[4]));
            UnMarriedWoman.Add(Convert.ToInt16(row[0]), Convert.ToString(row[3]));
        }

    }
}
