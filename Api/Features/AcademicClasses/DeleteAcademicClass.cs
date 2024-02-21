﻿using AutoMapper;
using MediatR;

namespace Api.Features.AcademicClasses;

public class DeleteAcademicClass
{
    public record Command : IRequest<int?>
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, int?>
    {
        private readonly IMapper _mapper;
        private readonly IAcademicClassesRepository _repository;

        public Handler(
          IAcademicClassesRepository repository,
          IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int?> Handle(
          Command command,
          CancellationToken cancellationToken)
        {
            var deleted = await _repository.DeleteAsync(command.Id, cancellationToken);
            return deleted;
        }
    }
}
