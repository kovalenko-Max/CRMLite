namespace CRMLite.CRMDAL
{
    public static class StringExtensions
    {
        public static string GetStoredProcedureName(this string fullName) =>
            fullName.Substring(0, fullName.LastIndexOf("Async"));
    }
}
