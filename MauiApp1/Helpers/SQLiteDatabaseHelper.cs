using SQLite;

namespace MauiApp1.Helpers
{
    internal class SQLiteDatabaseHelper
    {
        public class SQliteDatabaseHelper
        {
            readonly SQLiteAsyncConnection _conn;

            public SQliteDatabaseHelper(string path)
            {
                _conn = new SQLiteAsyncConnection(path);
                _conn.CreateTableAsync<Tempo>().Wait();
            }

            public Task<int> Insert(Tempo t)
            {
                return _conn.InsertAsync(t);
            }


            public Task<int> Delete(int id)
            {
                return _conn.Table<Tempo>().DeleteAsync(i => i.Id == id);
            }

            public Task<List<Tempo>> GetAll()
            {
                return _conn.Table<Tempo>().ToListAsync();
            }

            public Task<List<Tempo>> Search(string q)
            {
                string sql = "SELECT * FROM Tempo WHERE description LIKE '%" + q + "%'";

                return _conn.QueryAsync<Tempo>(sql);
            }
        }
    }
}
