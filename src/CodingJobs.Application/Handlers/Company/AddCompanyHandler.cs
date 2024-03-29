﻿using AutoMapper;
using CodingJobs.Application.Commands.Company;
using CodingJobs.Contracts.Requests.Company;
using CodingJobs.Contracts.Responses.Company;
using CodingJobs.Infrastructure.Database;
using FluentValidation;
using Mediator;

namespace CodingJobs.Application.Handlers.Company;

public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, CompanyResponse>
{
    private readonly IValidator<AddCompanyRequest> _validator;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddCompanyHandler(IValidator<AddCompanyRequest> validator, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async ValueTask<CompanyResponse> Handle(AddCompanyCommand command, CancellationToken cancellationToken)
    {
        var validatedResult = await _validator.ValidateAsync(command.Request, cancellationToken);
        if (!validatedResult.IsValid)
        {
            throw new ValidationException(validatedResult.Errors);
        }
        
        var company = _mapper.Map<Domain.Models.Company>(command.Request);
        var result = await _unitOfWork.CompanyRepository.AddAsync(company);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<CompanyResponse>(result);
    }
}