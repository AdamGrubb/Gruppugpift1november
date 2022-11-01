using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Grupparbete1november
{
    public class DailyWeatherDate
    {
        public int Grader { get; set; }
        public bool Sunny { get; set; }

        public int WindPower { get; set; }

        public Clouds ShapeOfClouds { get; set; }

        public DailyWeatherDate(int grader, bool sunny, int windPower, Clouds shapeOfClouds)
        {
            Grader = grader;
            Sunny = sunny;
            WindPower = windPower;
            ShapeOfClouds = shapeOfClouds;
        }
    }

}
public enum Clouds
{
    Klart,
    Stackmoln,
    Valkmoln,
    Dimmoln,
    Böljemoln,
    Makrillmoln
}
