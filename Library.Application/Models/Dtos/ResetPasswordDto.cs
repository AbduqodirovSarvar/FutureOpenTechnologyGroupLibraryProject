namespace Library.Application.Models.Dtos
{
    public record ResetPasswordDto(string Email, int ConfirmationCode);
}
