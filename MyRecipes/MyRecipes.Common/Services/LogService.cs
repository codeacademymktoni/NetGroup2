using Microsoft.Extensions.Configuration;
using MyRecipes.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyRecipes.Common.Services
{
    public class LogService : ILogService
    {
        private readonly string _filePath;

        public LogService(IConfiguration configuration)
        {
            _filePath = configuration["LogFilePath"];
        }

        public void Log(LogData logData)
        {
            switch (logData.Type)
            {
                case LogType.Info:
                    File.AppendAllLines($"Info_{DateTime.Now.ToString("yyyy_MM_dd")}_{_filePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                case LogType.Warning:
                    File.AppendAllLines($"Warning_{DateTime.Now.ToString("yyyy_MM_dd")}_{_filePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                case LogType.Error:
                    File.AppendAllLines($"Error_{DateTime.Now.ToString("yyyy_MM_dd")}_{_filePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                default:
                    throw new NotImplementedException(logData.Type.ToString());
            }
        }
    }
}
