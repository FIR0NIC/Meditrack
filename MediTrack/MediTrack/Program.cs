using Microsoft.Win32;
using MediTrack.StartUpForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediTrack
{
    internal static class Program
    {
        private static bool _isShuttingDown = false;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Handle system shutdown/logoff
            SystemEvents.SessionEnding += SystemEvents_SessionEnding;

            // Set up global exception handlers for crash detection
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Handle UI thread exceptions
            Application.ThreadException += Application_ThreadException;

            // Handle non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //await DatabaseService.InitializeAsync();
            DatabaseService.InitializeAsync().GetAwaiter().GetResult();

            //Properties.Settings.Default.Reset();
            //Properties.Settings.Default.Save();
            if (Properties.Settings.Default.DontShowWelcome)
            {
                Application.Run(new LogInForm()); // Skip welcome, go straight to login if user checked the box to skip it
            }
            else
            {
                Application.Run(new WelcomeFrm()); // Show welcome if not set to skip
            }
            //Application.Run(new LogInForm());
            //Application.Run(new CashierDashboard()); 
            //Application.Run(new AdminDashboard());
        }

        /// <summary>
        /// Handles system shutdown or user logoff
        /// </summary>
        private static async void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            if (_isShuttingDown) return;
            _isShuttingDown = true;

            System.Diagnostics.Debug.WriteLine($"=== SYSTEM SHUTDOWN/LOGOFF DETECTED at {DateTime.Now} ===");
            System.Diagnostics.Debug.WriteLine($"Reason: {e.Reason}");

            // Terminate all active sessions
           // await CrashRecoveryService.TerminateAllSessionsOnCrashAsync();

            // Give a moment for the operation to complete
            await Task.Delay(500);
        }

        /// <summary>
        /// Handles unhandled exceptions from the UI thread
        /// </summary>
        private static async void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            await HandleCrashAsync(e.Exception);
        }

        /// <summary>
        /// Handles unhandled exceptions from non-UI threads
        /// </summary>
        private static async void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                await HandleCrashAsync(ex);
            }
        }

        /// <summary>
        /// Handles application crash by terminating active sessions and logging the error
        /// </summary>
        private static async Task HandleCrashAsync(Exception exception)
        {
            if (_isShuttingDown) return;

            // Log the crash for debugging
            System.Diagnostics.Debug.WriteLine($"=== CRASH DETECTED at {DateTime.Now} ===");
            System.Diagnostics.Debug.WriteLine($"Error: {exception.Message}");
            System.Diagnostics.Debug.WriteLine($"Stack Trace: {exception.StackTrace}");

            // Save crash log to file for troubleshooting
            string crashLogPath = $"crash_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            try
            {
                await System.IO.File.WriteAllTextAsync(crashLogPath,
                    $"Time: {DateTime.Now}\n" +
                    $"Message: {exception.Message}\n" +
                    $"Stack Trace: {exception.StackTrace}\n" +
                    $"Source: {exception.Source}\n" +
                    $"Target Site: {exception.TargetSite}");
            }
            catch (Exception logEx)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to write crash log: {logEx.Message}");
            }

            // Terminate all active sessions from this app instance
            //await CrashRecoveryService.TerminateAllSessionsOnCrashAsync();

            // Show error message to user
            MessageBox.Show(
                $"The application has encountered an unexpected error and will close.\n\n" +
                $"Error: {exception.Message}\n\n" +
                $"All active sessions have been terminated.\n" +
                $"You may log in again after restarting the application.\n\n" +
                $"Crash log saved to: {crashLogPath}\n\n" +
                $"Please contact support if this issue persists.",
                "Application Error - Crash Detected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            // Exit the application
            Environment.Exit(1);
        }
    }
}