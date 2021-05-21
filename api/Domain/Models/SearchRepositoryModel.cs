using System;

public interface SearchRepositoryRequestModel
{
    string profile { get; set; }
    string language { get; set; }
    DateTime create_at { get; set; }
    int limit { get; set; }
}

public interface SearchRepositoryResultModel
{
    public string name { get; set; }
    public string full_name { get; set; }
    public string language { get; set; }
    public string created_at { get; set; }
}