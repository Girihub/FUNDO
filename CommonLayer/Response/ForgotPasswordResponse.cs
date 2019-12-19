//----------------------------------------------------
// <copyright file="ForgotPasswordResponse.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Response
{
    public class ForgotPasswordResponse
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
