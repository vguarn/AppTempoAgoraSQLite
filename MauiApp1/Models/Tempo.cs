using SQLite;

public class Tempo
{
    internal double lat;
    internal double lon;
    internal string main;
    internal double tempo_min;
    internal double tempo_max;
    internal double speed;
    internal int visitility;
    internal string sunrise;
    internal string sunset;

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Cidade { get; set; }
    public string Data { get; set; }
    public string Temperatura { get; set; }
    public string Condicao { get; set; }
    public string description { get; internal set; }
}