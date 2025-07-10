﻿namespace Person_Api.Moduls;

public class Pagination<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public List<T> Data { get; set; } = new List<T>();
}