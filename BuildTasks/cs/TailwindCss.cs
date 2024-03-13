using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace CustomTasks
{
    public class TailwindCss : ContextAwareTask
    {
        [Required]
        public string In{ get; set; }
        
        [Required]
        public string Out { get; set; }

        [Required]
        public string ProjectDirectory { get; set; }

        public string TailwindCssPath { get; set; }
        
        public bool watch { get; set; }
        
        [Output]
        public string Output { get; set; }

        protected override bool ExecuteInner()
        {
            return !Log.HasLoggedErrors;
        }
    }
}

namespace BuildChain
{
    public static class Target {

        public static class TailwindCss{
            private static Process Run(
                string In,
                string Out,
                string MSBuildProjectDirectory,
                string TailwindCssPath,
                bool watch = false
            )
            {
                if (TailwindCssPath == null)
                {
                    TailwindCssPath = Util.FindBin("tailwindcss");
                }

                string arguments = $"-i {In} -o {Out}";
                if (watch)
                {
                    arguments += " -w";
                }

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = TailwindCssPath,
                        Arguments = arguments,
                        WorkingDirectory = MSBuildProjectDirectory,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                    
                    },
                    EnableRaisingEvents = true
                };
            
                return process;
            }

            public static int Build(
                string In,
                string Out,
                string MSBuildProjectDirectory,
                string TailwindCssPath,
                out string TailwindOutput,
                out string TailwindError
            )
            {
                var process = Run(In, Out, MSBuildProjectDirectory, TailwindCssPath, false);

                process.Start();
                TailwindOutput = process.StandardOutput.ReadToEnd();
                TailwindError = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine(TailwindOutput);
                Console.WriteLine(TailwindError);
                return process.ExitCode;
            }
            
            public static void Watch(
                string In,
                string Out,
                string MSBuildProjectDirectory,
                string TailwindCssPath,
                out string TailwindOutput,
                out string TailwindError
            )
            {
                var process = Run(In, Out, MSBuildProjectDirectory, TailwindCssPath, false);

                process.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        Console.WriteLine($"Output: {e.Data}");
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        Console.WriteLine($"Error: {e.Data}");
                    }
                };  

                process.Start();

                TailwindOutput = process.StandardOutput.ReadToEnd();
                TailwindError = process.StandardError.ReadToEnd();

                return;
            }
        }
    }
}