namespace Application.Features.Auth.Commands.Register;

public class RegisteredResponse
    //Status tutulabilir -> Kayıt olan kullanıcının direkt giriş yapması veya email doğrulaması gibi seçenekler için.
{
    public string Token { get; set; }
}
