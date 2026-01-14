using _365EJSC.ERP.Domain.Abstractions.Aggregates;

namespace _365EJSC.ERP.Domain.Entities.Define
{
    public class ConfigIcon : AggregateRoot<string>
    {
        /// <summary>
        /// Description of the ConfigIcon
        /// </summary>
        public string IconDescription { get; set; }

        /// <summary>
        /// Url of the ConfigIcon
        /// </summary>
        public string IconUrl { get; set; } = string.Empty;
    }
}
