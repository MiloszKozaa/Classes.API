using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classes.Dtos
{
    public class ExternalProfileDTO
    {
        public Guid Id { get; private set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;

        public static ExternalProfileDTO From(Models.ExternalProfile externalProfile) => new ExternalProfileDTO
        {
            Id = externalProfile.Id,
            Username = externalProfile.Username,
            Name = externalProfile.Name,
            Link = externalProfile.Link,
        };
        public static List<ExternalProfileDTO> From(List<Models.ExternalProfile> externalProfiles)
        {
            return externalProfiles.Select(From).ToList();
        }

        internal static List<ExternalProfileDTO> From(object externalProfiles)
        {
            throw new NotImplementedException();
        }
    }
}