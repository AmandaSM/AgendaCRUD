using System;
using System.Data.SQLite;

namespace AgendaCrud.Data
{
    //Criando o caminho da pasta onde ira ficar o banco
    public class SqLiteBaseRepository
    {
        //Criando uma pasta no projeto AgendaCrud a onde ficara o banco
        public static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\SimpleDb.sqlite"; }
        }
        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }
    }
}
