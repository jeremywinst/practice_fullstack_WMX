namespace HMI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        //----------------------------------------------------------------------------------------
        // The HMI will automatically open the C++ program so just need to open this HMI
        // and you are good to go
        // 
        // The log file can be found in the log folder located at the same folder with the HMI.
        // The joblist file located in the HMI\\joblist folder
        // The axis.ini file located in the same folder as the HMI.exe
        //----------------------------------------------------------------------------------------

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}