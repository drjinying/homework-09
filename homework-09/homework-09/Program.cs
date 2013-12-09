using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Threading;

namespace homework_09
{
    static class Program
    {
        private static System.Threading.Mutex mutex;

        [STAThread]
        static void Main()
        {
            mutex = new System.Threading.Mutex(true, "OnlyRun");

            // if another instance is running, pipe to it and exit
            if(!mutex.WaitOne(0, false))
            {
                NamedPipeClientStream pipeClient =
                new NamedPipeClientStream("localhost", "pipenewtab",
                PipeDirection.InOut, PipeOptions.None,
                TokenImpersonationLevel.Impersonation);
                StreamWriter psw = new StreamWriter(pipeClient);
                StreamReader psr = new StreamReader(pipeClient);
                pipeClient.Connect();
                psw.AutoFlush = true;
                String PipeStringAnti = "@#$%^&*("; // for security, 
                                                    // both pipe-end should ask for this string to recognize identity
                if (psr.ReadLine() == PipeStringAnti)
                {
                    string s = "1"; // tell pipe server add a new tab
                    psw.WriteLine(s);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Pipe Server Not Verified");
                    Application.Exit();
                }
            }
                // if no instance is running
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                PipeServer pipe_server = new PipeServer();
                pipe_server.startPipe();
            }
        }

        private class PipeServer
        {
            private String PipeStringAnti = "@#$%^&*(";
            public Thread ThreadPipe;
            public void startPipe()
            {
                ThreadPipe = new Thread(new ThreadStart(waitPipe));
                ThreadPipe.IsBackground = true;
                ThreadPipe.Start();
            }

            private void waitPipe()
            {
                while (true)
                {
                    using (NamedPipeServerStream pipeServer =
                            new NamedPipeServerStream("pipenewtab", PipeDirection.InOut, 1))
                    {
                        pipeServer.WaitForConnection();
                        try
                        {
                            using (StreamReader psr = new StreamReader(pipeServer))
                            using (StreamWriter psw = new StreamWriter(pipeServer))
                            {
                                psw.AutoFlush = true;
                                psw.WriteLine(PipeStringAnti);
                                String WebInstrStr = psr.ReadLine();
                                if(WebInstrStr == "1")
                                {
                                    MessageBox.Show("Open new file or press auto input to start new demo");
                                }
                                else
                                {
                                    MessageBox.Show("a");
                                }
                            }
                        }
                        catch (IOException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }
            }
        }

    }
}
