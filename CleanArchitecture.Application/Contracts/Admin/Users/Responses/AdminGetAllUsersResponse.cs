﻿namespace CleanArchitecture.Application.Contracts.Admin.Users.Responses;
public class AdminGetAllUsersResponse
{
    public Guid id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
}
