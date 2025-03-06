using System.Management;
using System.Runtime.Versioning;

namespace AntivirusStatusChecker.AVStatusChecker;

/// <summary>
/// Responsável por consultar e exibir o status dos antivírus instalados via WMI.
/// </summary>
[SupportedOSPlatform("windows")]
public static class AVStatusChecker
{
    private const string WmiScope = @"\\.\root\SecurityCenter2";
    private const string WmiQuery = "SELECT * FROM AntiVirusProduct";

    /// <summary>
    /// Consulta o status dos antivírus a cada 1 segundos até encontrar um antivírus com assinatura desatualizada.
    /// </summary>
    public static async Task CheckAntivirusStatusAsync()
    {
        while (true)
        {
            using var searcher = new ManagementObjectSearcher(WmiScope, WmiQuery);
            using var results = searcher.Get();

            foreach (var av in results.Cast<ManagementObject>())
            {
                var name = av["displayName"]?.ToString() ?? "Unknown";
                var productState = (uint)(av["productState"] ?? 0);

                var protectionStatus = GetProtectionStatus(productState);
                var signaturesStatus = GetSignaturesStatus(productState);

                var antivirusInfo = new AntivirusInfo(name, protectionStatus, signaturesStatus);
                Console.WriteLine(antivirusInfo.ToString());
            }

            await Task.Delay(5000);
        }
    }

    /// <summary>
    /// Interpreta o estado do produto para determinar o status da proteção em tempo real.
    /// </summary>
    /// <param name="productState">Valor numérico que representa o estado do produto.</param>
    /// <returns>Uma string descritiva do status da proteção.</returns>
    private static string GetProtectionStatus(uint productState)
    {
        var realTimeOn = (productState & 0xF000) == 0x1000;
        var realTimeSnoozed = (productState & 0xF000) == 0x2000;
        var realTimeExpired = (productState & 0xF000) == 0x3000;

        if (realTimeOn && !realTimeSnoozed && !realTimeExpired)
            return "Habilitada";
        if (realTimeSnoozed)
            return "Pausada/Suspensa";
        if (realTimeExpired)
            return "Expirada (desatualizada ou licença expirada)";

        return "Desabilitada";
    }

    /// <summary>
    /// Interpreta o estado do produto para determinar o status das assinaturas (banco de vírus).
    /// </summary>
    /// <param name="productState">Valor numérico que representa o estado do produto.</param>
    /// <returns>Uma string descritiva do status das assinaturas.</returns>
    private static string GetSignaturesStatus(uint productState)
    {
        var signaturesOutOfDate = (productState & 0xF0) == 0x10;
        return signaturesOutOfDate ? "Desatualizadas" : "Atualizadas";
    }
}