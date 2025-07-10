using Microsoft.AspNetCore.Mvc;

namespace Person_Api.Repositories;

public class EmployeeService: IEmployeeService
{
    private readonly IPersonRepository _personRepository;
    public EmployeeService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    
}