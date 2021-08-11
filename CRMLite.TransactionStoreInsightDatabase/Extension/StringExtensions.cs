namespace CRMLite.TransactionStoreInsightDatabase.Extension
{
    public static class StringExtensions
    {
        public static string GetStoredProcedureName(this string fullName)
        {
            var result = fullName.Substring(0, fullName.LastIndexOf("Async"));
            result = $"[CRMLite].[{result}]";

            return result;
        }
    }
}
