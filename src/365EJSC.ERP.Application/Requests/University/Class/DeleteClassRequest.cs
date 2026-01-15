using _365EJSC.ERP.Contract.Abstractions;

namespace _365EJSC.ERP.Application.Requests.University.Class
{
    public record DeleteClassRequest : ICommand
    {
        public int? Id { get; set; }
    }
}