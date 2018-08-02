namespace CldMedAPI.Controler
{
    internal class QueryStrings
    {
        public static string selectPerData= "SELECT U.Id as 'Uid', U.Name as 'Name', U.Username as 'Username',"+
            " P.Id as 'Pid', P.Interval as 'Inter', P.Count as 'Count', P.Dose as 'Dose', M.Id as 'Mid', M.Name as 'MName',  M.Barcode as 'Barcode' " +
            "FROM[Users] AS U INNER JOIN [Perscripts] AS P ON U.Id=P.UId INNER JOIN [Medicine] as M ON P.MId=M.Id WHERE U.HId=@par;";
    }
}
