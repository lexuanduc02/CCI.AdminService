﻿namespace CCI.Model.CommonModels
{
    public class BaseResponseModel<T>
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; } = 0;
        public bool Success { get; set; }
        public T? Data { get; set; }
    }
}
