using System.ComponentModel.DataAnnotations;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.CharacterConst;
using static UniverseApp.Infrastructure.Constants.ModelsConstants.General;
namespace UniverseApp.Core.Models.Character
{
    public class CharacterFormModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMesssage)]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public required string Name { get; set; }

        [StringLength(HeightMaxLenght, MinimumLength = HeightMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Height { get; set; }

        [StringLength(MassMaxLenght, MinimumLength = MassMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Mass { get; set; }

        [StringLength(HairColorMaxLenght, MinimumLength = HairColorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? HairColor { get; set; }

        [StringLength(SkinColorMaxLenght, MinimumLength = SkinColorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? SkinColor { get; set; }

        [StringLength(EyeColorMaxLenght, MinimumLength = EyeColorMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? EyeColor { get; set; }

        [StringLength(BirthYearMaxLenght, MinimumLength = BirthYearMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? BirthYear { get; set; }

        [StringLength(GenderMaxLenght, MinimumLength = GenderMinLenght, ErrorMessage = FieldMinMaxLengthErrorMesssage)]
        public string? Gender { get; set; }
    }
}
