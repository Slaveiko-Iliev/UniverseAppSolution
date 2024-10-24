using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseApp.Infrastructure.Data
{
    public class Constants
    {
        public static class PlanetConst
        {
            public const int NameMinLenght = 3;
            public const int NameMaxLenght = 50;
            public const int RotationOrbitalPeriodMinLenght = 1;
            public const int RotationOrbitalPeriodMaxLenght = 7;
            public const int ClimateMinLenght = 3;
            public const int ClimateMaxLenght = 30;
            public const int GravityMinLenght = 10;
            public const int GravityMaxLenght = 20;
            public const int TerrainMinLenght = 4;
            public const int TerrainMaxLenght = 60;
            public const int SurfaceWaterMinLenght = 1;
            public const int SurfaceWaterMaxLenght = 7;
            public const int PopulationMinLenght = 1;
            public const int PopulationMaxLenght = 15;
            public const int ResidentsMaxLenght = 300;
            public const int FilmsMaxLenght = 300;
            public const int UrlMinLenght = 4;
            public const int UrlMaxLenght = 70;
        }

        public static class MovieConst
        {
            public const int TitleMinLenght = 60;
            public const int TitleMaxLenght = 60;
            public const int DtoEpisodeIdMinLenght = 1;
            public const int DtoEpisodeIdMaxLenght = 2;
            public const int DescriptionMinLenght = 50;
            public const int DescriptionMaxLenght = 500;
            public const int DirectorMinLenght = 6;
            public const int DirectorMaxLenght = 100;
            public const int ProducerMinLenght = 6;
            public const int ProducerMaxLenght = 100;
            public const int UrlMinLenght = 4;
            public const int UrlMaxLenght = 70;
        }

        public const string FieldMinMaxLengthErrorMesssage = "The {0} must be between {2} and {1} characters long.";
    }
}
