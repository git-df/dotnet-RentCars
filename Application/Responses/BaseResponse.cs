using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(bool success)
        {
            Success = success;
        }

        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse(ValidationResult validationResult)
        {
            ValidationErrors = new List<String>();
            Success = !validationResult.Errors.Any();
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
        }

        public BaseResponse(ValidationResult validationResult, string message)
        {
            ValidationErrors = new List<String>();
            Success = !validationResult.Errors.Any();
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
            Message = message;
        }

        public BaseResponse(ValidationResult validationResult, string message, bool success)
        {
            ValidationErrors = new List<String>();
            Success = success;
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
            Message = message;
        }
    }

    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public int DataCount { get; set; } = 0;
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(bool success)
        {
            Success = success;
        }

        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse(ValidationResult validationResult)
        {
            ValidationErrors = new List<String>();
            Success = !validationResult.Errors.Any();
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
        }

        public BaseResponse(ValidationResult validationResult, string message)
        {
            ValidationErrors = new List<String>();
            Success = !validationResult.Errors.Any();
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
            Message = message;
        }

        public BaseResponse(ValidationResult validationResult, string message, bool success)
        {
            ValidationErrors = new List<String>();
            Success = success;
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
            Message = message;
        }

        public BaseResponse(T data)
        {
            Success = true;
            Data = data;
            DataCount = 1;
        }

        public BaseResponse(T data, int dataCount)
        {
            Success = true;
            Data = data;
            DataCount = dataCount;
        }

        public BaseResponse(T data, string message)
        {
            Success = true;
            Data = data;
            Message = message;
            DataCount = 1;
        }

        public BaseResponse(T data, int dataCount, string message)
        {
            Success = true;
            Data = data;
            Message = message;
            DataCount = dataCount;
        }

        public BaseResponse(T data, string message, bool success)
        {
            Success = success;
            Data = data;
            Message = message;
            DataCount = 1;
        }

        public BaseResponse(T data, int dataCount, string message, bool success)
        {
            Success = success;
            Data = data;
            Message = message;
            DataCount = dataCount;
        }
    }
}
