namespace MinhaAgenda.Plugins.SqlLite
{
    public class Constantes
    {
        public const string _databasefilename = "ContatosSqlLite.db3";
        public static string _databasepath => Path.Combine(FileSystem.AppDataDirectory, _databasefilename);
    }
}
