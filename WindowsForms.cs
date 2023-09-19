using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleAsyncWindowsFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            // Disable the button while the asynchronous operation is in progress.
            btnStart.Enabled = false;

            // Start the asynchronous operation.
            string result = await PerformAsyncOperation();

            // Display the result in a MessageBox.
            MessageBox.Show($"Async Operation Result: {result}", "Async Await Example");

            // Re-enable the button after the operation is complete.
            btnStart.Enabled = true;
        }

        private async Task<string> PerformAsyncOperation()
        {
            // Simulate an asynchronous operation by adding a delay.
            await Task.Delay(3000); // Delay for 3 seconds.

            // Return a result after the operation is complete.
            return "Async Operation Completed!";
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
