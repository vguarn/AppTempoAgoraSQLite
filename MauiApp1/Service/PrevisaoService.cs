using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PrevisaoService
{
    private SQLiteAsyncConnection _database;

    public PrevisaoService(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<PrevisaoTempo>().Wait();
    }

    public Task<int> AdicionarPrevisaoAsync(PrevisaoTempo previsao)
    {
        return _database.InsertAsync(previsao);
    }

    public Task<List<PrevisaoTempo>> ObterPrevisoesAsync()
    {
        return _database.Table<PrevisaoTempo>().OrderByDescending(p => p.Data).ToListAsync();
    }
}