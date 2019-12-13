//----------------------------------------------------
// <copyright file="ErrorMessages.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace CommonLayer.Constants
{
    /// <summary>
    /// Class to throw errors
    /// </summary>
    public class ErrorMessages
    {
        /// <summary>
        /// static field for null model validation
        /// </summary>
        public static string nullModel = "Model can not be null";

        /// <summary>
        /// static field for null id validation
        /// </summary>
        public static string nullId = "Id can not be null";

        /// <summary>
        /// static field for invalid validation
        /// </summary>
        public static string invalidId = "Id is invalid";

        /// <summary>
        /// static field for invalid Service Type
        /// </summary>
        public static string invalidServiceType = "Enter service type as either Basic or Advance";

    }
}
