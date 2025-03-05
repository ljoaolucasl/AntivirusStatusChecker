namespace AntivirusStatusChecker.AVStatusChecker;

/// <summary>
/// Representa o status de um antivírus instalado.
/// </summary>
internal class AntivirusInfo(string name, string protectionStatus, string signaturesStatus)
{
    public string Name { get; set; } = name;
    public string ProtectionStatus { get; set; } = protectionStatus;
    public string SignaturesStatus { get; set; } = signaturesStatus;

    /// <summary>
    /// Retorna uma representação formatada dos dados do antivírus.
    /// </summary>
    /// <returns>Uma string com os valores formatados.</returns>
    public override string ToString()
    {
        return $"Antivírus: {Name}\n" +
               $"  Proteção em tempo real: {ProtectionStatus}\n" +
               $"  Status do banco de vírus: {SignaturesStatus}\n";
    }
}