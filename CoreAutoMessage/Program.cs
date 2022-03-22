CheckProcess();

await Host.CreateDefaultBuilder()
        .ConfigureServices(services =>
        {
            services.AddSingleton<CoreLicense>();
            services.AddSingleton<AutoMessageDefinitions>();
            services.AddSingleton<GProvider>();
            services.AddSingleton<LogWriter>();            

            services.AddHostedService<LicenseControl>();
            services.AddHostedService<AutoMessageWorker>();            
        }).Build().RunAsync();

void CheckProcess()
{
    Console.WriteLine("CHECANDO PROCESSOS EXISTENTES\n");

    Process p = Process.GetCurrentProcess();
    var ProcessesList = Process.GetProcessesByName(p.ProcessName);

    for (int i = 0; i < ProcessesList.Length - 1; i++)
    {
        if (!ProcessesList[i].Equals(p))
        {
            ProcessesList[i].Kill();
            Console.WriteLine("ELIMINANDO PROCESSO PRÉ-EXISTENTE");
        }
    }
}