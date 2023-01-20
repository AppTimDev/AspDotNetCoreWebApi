using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreWebApi.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class AddPageRequest
    {
        public string? Name { get; set; }
    }
    public class UpdatePageRequest
    {        
        public string? Name { get; set; }
    }
}
