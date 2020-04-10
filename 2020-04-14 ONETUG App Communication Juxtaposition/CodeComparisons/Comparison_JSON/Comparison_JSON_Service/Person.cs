using System;

namespace Comparison_JSON_Service
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public EmailType[]? AllowedEmailTypes { get; set; }
        public int[]? FamilyMemberIds { get; set; }
        public Setting[]? Preferences { get; set; }
    }

    public class Setting
    { 
        public string? Name { get; set; }
        public string? Value { get; set; }
    }

    public enum EmailType
    { 
        Promotional,
        HappyBirthday,
        AccountCreationAnniversary
    }
}
