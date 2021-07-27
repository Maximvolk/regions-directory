using RegionsDirectory.Core.Models;
using RegionsDirectory.Common;

namespace RegionsDirectory.Core.Responses
{
    public class RegionResponse : BaseResponse<Region>
    {
        /// <summary>
        /// Creates a success response
        /// </summary>
        /// <param name="region">Saved region.</param>
        /// <returns>Response.</returns>
        public RegionResponse(Region region) : base(region) {}

        /// <summary>
        /// Creates an error response
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public RegionResponse(string message, CustomerCodes code) : base(message, code) {}
    }
}