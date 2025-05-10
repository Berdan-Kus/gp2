using AutoMapper;
using gp2.Models;
using gp2.DTOs.TransactionDTOs;
using gp2.DTOs.UserDTOs;


namespace gp2.Helpers.AutoMapperProfiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, GetTransactionDTO>();
            CreateMap<GetTransactionDTO, Transaction>();

            CreateMap<Transaction, CreateTransactionDTO>();
            CreateMap<CreateTransactionDTO, Transaction>();

            CreateMap<Transaction, DeleteTransactionDTO>();
            CreateMap<DeleteTransactionDTO, Transaction>();

            CreateMap<Transaction, UpdateTransactionDTO>();
            CreateMap<UpdateTransactionDTO, Transaction>();
            

        }
    }
}
