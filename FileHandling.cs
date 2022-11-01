using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Grupparbete1november
{
    public class FileHandling
    {
        public async Task WriteToFile(List<DailyWeatherDate> toSave)
        {
            await Task.Delay(5000);
            string fileName = "WeatherForecast.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, toSave); //Kan ta tid.
            await createStream.DisposeAsync(); //Stänger ner async. - Förklara gärna.
        }
    }
}
