namespace Palamut.Web.Api.Services.Model
{
    public class SearchResult<T>
    {
        public T ResultObject;
        public string ResultMessage;
        public ResultType ResultType;
    }
    public enum ResultType : byte
    {
        Success = 0,
        Error = 1,
        Warning = 2,
    }
}
