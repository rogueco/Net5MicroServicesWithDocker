// -----------------------------------------------------------------------
// <copyright company="N/A." file="EmailSettings.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

namespace Ordering.Application.Models
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}