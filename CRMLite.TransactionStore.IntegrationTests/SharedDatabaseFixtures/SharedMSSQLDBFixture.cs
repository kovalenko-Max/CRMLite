using System.Diagnostics;

namespace CRMLite.TransactionStore.IntegrationTests.SharedDatabaseFixtures
{
    public class SharedMSSQLDBFixture : ISharedDatadaseFixture
    {
        private const string _testDBName = "CRMLite.TransactionStoreDB.Test";
        private static  bool isCreatedDB = false;

        public void PublishDBForTest()
        {
            if (!isCreatedDB)
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                string solutionPath = path.Replace(@"\CRMLite.TransactionStore.IntegrationTests\bin\Debug\net5.0", "");
                string projectPath = path.Replace(@"\bin\Debug\net5.0", "");
                string dacpacFilePath = @$"{solutionPath}\CRMLite.TransactionStoreDatabase\bin\Debug\CRMLite.TransactionStoreDB.dacpac";

                ProcessStartInfo procStartInfo = new ProcessStartInfo();
                procStartInfo.FileName = projectPath + @"\sqlpackage\sqlpackage.exe";
                procStartInfo.Arguments = @$"/sf:{dacpacFilePath} /a:Publish /p:CreateNewDatabase=true /tsn:(LocalDB)\MSSQLLocalDB /tdn:{_testDBName} /v:DbType=production  /v:DbVer=1.0.0 /p:ScriptNewConstraintValidation=False /p:GenerateSmartDefaults=True /of:True /p:BlockOnPossibleDataLoss=False";

                using (Process process = new Process())
                {
                    process.StartInfo = procStartInfo;
                    process.Start();
                    process.WaitForExit();
                }
                isCreatedDB = true;
            }
        }
    }
}
