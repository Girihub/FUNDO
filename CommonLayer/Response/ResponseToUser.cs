//----------------------------------------------------
// <copyright file="LoginResponse.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Response
{
    public class ResponseToUser
    {
        /// <summary>
        /// Gets or sets Id of user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets First Name of user
        /// </summary>        
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name of user 
        /// </summary>        
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Mobile Number of user 
        /// </summary>        
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets Email of user 
        /// </summary>        
        public string Email { get; set; }        

        /// <summary>
        /// Gets or sets Profile Picture of user
        /// </summary>
        public string ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets Service Type of user
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// Gets or sets User Type of user
        /// </summary>
        public string UserType { get; set; }
    }
}
