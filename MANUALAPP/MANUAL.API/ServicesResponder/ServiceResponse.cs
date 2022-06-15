using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.ServicesResponder
{
    //I will use this Generic class to wrap our API response to provide a more meaningful response when a request is sent to our API.
    /// <summary>
    /// Generic wrapper for web api response. 
    /// This class is a Generic classes whom encapsulate operations that are not specific to a particular data type until the class and/or their methods are declared and instantiated .
    /// By using a generic type parameter T, I can write a single class that other client code can use without incurring the cost or risk of runtime casts or boxing operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T> // here I use <> to specified Parameter Type.
    {
        public ServiceResponse(bool success = true, string message = null, string error = null, List<string> errorMessage= null)
        {
            this.Success = success;
            this.Message = message;
            this.Error = error;
            this.ErrorMessages = errorMessage;
            
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
