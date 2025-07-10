/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Repositories;

namespace Final.Application.Features.Commands.Prescriptions.DeletePrescription
{
    public class DeletePrescriptionCommandHandlerIRequestHandler<DeletePrescriptionCommandRequest, bool>
    {
        private readonly IPrescriptionWriteRepository _writeRepository;

        public DeletePrescriptionCommandHandler(IPrescriptionWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<bool> Handle(DeletePrescriptionCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}*/
