using SQLite;

public class PrevisaoTempo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Cidade { get; set; }
    public string Data { get; set; }
    public string Temperatura { get; set; }
    public string Condicao { get; set; } 
}