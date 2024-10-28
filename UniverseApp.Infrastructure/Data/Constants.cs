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

        public static class CharacterConst
        {
            public const int NameMinLenght = 3;
            public const int NameMaxLenght = 30;
            public const int HeightMinLenght = 1;
            public const int HeightMaxLenght = 3;
            public const int MassMinLenght = 1;
            public const int MassMaxLenght = 3;
            public const int HairColorMinLenght = 3;
            public const int HairColorMaxLenght = 20;
            public const int SkinColorMinLenght = 3;
            public const int SkinColorMaxLenght = 20;
            public const int EyeColorMinLenght = 3;
            public const int EyeColorMaxLenght = 20;
            public const int BirthYearMinLenght = 4;
            public const int BirthYearMaxLenght = 10;
            public const int GenderMinLenght = 4;
            public const int GenderMaxLenght = 6;
            public const int UrlMinLenght = 4;
            public const int UrlMaxLenght = 70;
            public const int HomeworldMinLenght = 4;
            public const int HomeworldMaxLenght = 50;
        }

        public static class SpecieConst
        {
            public const int NameMinLenght = 3;
            public const int NameMaxLenght = 30;
            public const int ClassificationMinLenght = 3;
            public const int ClassificationMaxLenght = 30;
            public const int DesignationMinLenght = 5;
            public const int DesignationMaxLenght = 30;
            public const int AverageHeightMinLenght = 1;
            public const int AverageHeightMaxLenght = 3;
            public const int SkinColorsMinLenght = 3;
            public const int SkinColorsMaxLenght = 50;
            public const int HairColorsMinLenght = 3;
            public const int HairColorsMaxLenght = 50;
            public const int EyeColorsMinLenght = 3;
            public const int EyeColorsMaxLenght = 50;
            public const int AverageLifespanMinLenght = 1;
            public const int AverageLifespanMaxLenght = 3;
            public const int LanguageMinLenght = 3;
            public const int LanguageMaxLenght = 30;
            public const int HomeworldMinLenght = 4;
            public const int HomeworldMaxLenght = 50;
            public const int UrlMinLenght = 4;
            public const int UrlMaxLenght = 70;
        }

        public static class VehicleConst
        {
            public const int NameMinLenght = 3;
            public const int NameMaxLenght = 40;
            public const int ModelMinLenght = 3;
            public const int ModelMaxLenght = 40;
            public const int ManufacturerMinLenght = 3;
            public const int ManufacturerMaxLenght = 50;
            public const int CostInCreditsMinLenght = 1;
            public const int CostInCreditsMaxLenght = 15;
            public const int LengthMinLenght = 1;
            public const int LengthMaxLenght = 7;
            public const int MaxAtmospheringSpeedMinLenght = 1;
            public const int MaxAtmospheringSpeedMaxLenght = 4;
            public const int CrewMinLenght = 1;
            public const int CrewMaxLenght = 10;
            public const int PassengersMinLenght = 1;
            public const int PassengersMaxLenght = 10;
            public const int CargoCapacityMinLenght = 1;
            public const int CargoCapacityMaxLenght = 15;
            public const int ConsumablesMinLenght = 5;
            public const int ConsumablesMaxLenght = 20;
            public const int ClassMinLenght = 3;
            public const int ClassMaxLenght = 15;
            public const int UrlMinLenght = 4;
            public const int UrlMaxLenght = 70;
        }

        public static class StarshipConst
        {
            public const int HyperdriveRatingMinLenght = 1;
            public const int HyperdriveRatingMaxLenght = 3;
            public const int MGLTMinLenght = 1;
            public const int MGLTMaxLenght = 3;
        }

        public static class General
        {
            public const string FieldMinMaxLengthErrorMesssage = "The {0} must be between {2} and {1} characters long.";
        }
    }
}
