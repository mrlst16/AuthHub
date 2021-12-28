using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthHub.Database.SqlServer.Tests
{
    [TestClass()]
    public class usp_GetUser_UnitTest : SqlDatabaseTestClass
    {

        public usp_GetUser_UnitTest()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_usp_GetUserTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usp_GetUser_UnitTest));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_usp_GetUserTest_PretestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_usp_GetUserTest_PosttestAction;
            this.dbo_usp_GetUserTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_usp_GetUserTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_usp_GetUserTest_PretestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            dbo_usp_GetUserTest_PosttestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // dbo_usp_GetUserTest_TestAction
            // 
            resources.ApplyResources(dbo_usp_GetUserTest_TestAction, "dbo_usp_GetUserTest_TestAction");
            // 
            // dbo_usp_GetUserTest_PretestAction
            // 
            resources.ApplyResources(dbo_usp_GetUserTest_PretestAction, "dbo_usp_GetUserTest_PretestAction");
            // 
            // dbo_usp_GetUserTest_PosttestAction
            // 
            resources.ApplyResources(dbo_usp_GetUserTest_PosttestAction, "dbo_usp_GetUserTest_PosttestAction");
            // 
            // dbo_usp_GetUserTestData
            // 
            this.dbo_usp_GetUserTestData.PosttestAction = dbo_usp_GetUserTest_PosttestAction;
            this.dbo_usp_GetUserTestData.PretestAction = dbo_usp_GetUserTest_PretestAction;
            this.dbo_usp_GetUserTestData.TestAction = dbo_usp_GetUserTest_TestAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod(), ExpectedSqlException(Severity = 15, MatchFirstError = false, State = 1)]
        public void dbo_usp_GetUserTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_usp_GetUserTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        private SqlDatabaseTestActions dbo_usp_GetUserTestData;
    }
}
