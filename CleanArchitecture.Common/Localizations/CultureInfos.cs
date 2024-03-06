using System.Globalization;

namespace CleanArchitecture.Common.Localizations;
public static class SupportedCultureInfos
{
    public static string DEFAULT = "ge";
    public static Dictionary<string, CultureInfo> cultureInfos = new Dictionary<string, CultureInfo>();
    static SupportedCultureInfos()
    {
        cultureInfos.Add("en", new CultureInfo("en-US"));
        cultureInfos.Add("ge", new CultureInfo("ka-GE"));
    }

    public static CultureInfo GetCultureInfo(string language)
    {
        if (string.IsNullOrWhiteSpace(language)) return cultureInfos[DEFAULT];

        var isRightCulture = cultureInfos.ContainsKey(language);
        if (!isRightCulture) return cultureInfos[DEFAULT];

        return cultureInfos[language];

    }
    public static CultureInfo GetDefaultCulture()
    {
        return cultureInfos[DEFAULT];
    }
    public static List<CultureInfo> GetAllCultureInfoValues()
    {
        return cultureInfos.Values.ToList();
    }
    public static List<string> GetAllCultureInfoKeys()
    {
        return cultureInfos.Keys.ToList();
    }

}
