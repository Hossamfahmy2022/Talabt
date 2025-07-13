
namespace Talabt.Api.Errors
{
    public class ApiResponse
    {
        public int statusCode { get; set; }
        public string? message { get; set; }

        public ApiResponse(int statuscode , string? message = null)
        {
            statusCode = statuscode;
            this.message = message ?? GetDefaultMessageFromStatusCode(statusCode);
        }

        private string GetDefaultMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Ok",
                201 => "Created",
                400 => "BadRequest",
                403 => "UnAutherized",
                404 => "NotFound",
                405 => "NotMethodAllowd",
                500 => "Internal Server Error",
                _ => ""
            };
        }
    }
}
