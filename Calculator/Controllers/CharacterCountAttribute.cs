using System.ComponentModel.DataAnnotations;

public class CharacterCountAttribute : ValidationAttribute
{
    private readonly int _maxCharacters;

    public CharacterCountAttribute(int maxCharacters)
    {
        _maxCharacters = maxCharacters;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string stringValue)
        {
            if (stringValue.Length > _maxCharacters)
            {
                return new ValidationResult($"El campo {validationContext.DisplayName} no debe tener más de {_maxCharacters} caracteres.");
            }
        }

        return ValidationResult.Success;
    }
}
