using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SoftwareArchitecture.Application.Common.Logging
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Request
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}: Before => {typeof(TRequest).Name}");

            var response = await next();
            
            //Response
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}: After => {typeof(TRequest).Name} => {typeof(TResponse).Name}:{JsonSerializer.Serialize(response)}");
            
            return response;
        }
    }
}
